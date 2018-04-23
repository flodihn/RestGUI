using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AppSystem.Models;

public class TopMenu : MonoBehaviour
{
    public float slideSpeed = 1.0f;
    public float minimizeTimeout = 2.0f;
    public string minmizedText;
    public float minimizedHeightOffset;

    public float timeSinceLastMouseOver = 0f;
    private Vector3 minimizedPosition;
    private Vector3 maximizedPosition;
    private float timeProgressTime = 0f;

    private Container listContainer;
    private Camera topMenuCamera;

    public enum TopMenuState
    {
        Minimized,
        Maximized,
        Maximazing,
        Minimizing
    }

    public TopMenuState state;

    public void Awake()
    {
        topMenuCamera = GameObject.FindGameObjectWithTag("MenuCamera").GetComponent<Camera>();

    }

    public void Start()
    {
        minimizedPosition = transform.position;
        maximizedPosition = transform.position - new Vector3(0, minimizedHeightOffset, 0);

        state = TopMenuState.Minimized;

        listContainer = GetComponentInChildren<Container>();

        AppModes appModes = SystemApp.RestAPI.GetAppModes();
        foreach(AppMode appMode in appModes.appModes) {
            GameObject appModeButton = CreateModeAppItem(appMode);
            appModeButton.GetComponent<AppModeButton>().appMode = appMode;
            listContainer.AddItem(appModeButton);
        }
    }

    public void Update()
    {
        if(state == TopMenuState.Maximized) {
            timeSinceLastMouseOver += Time.deltaTime;
            if(timeSinceLastMouseOver > minimizeTimeout)
                Minimize();
            ResetTimeSinceLastMouseOverIfRayCastHit(); ;
        } else if(state == TopMenuState.Maximazing) {
            ProgressMaximazing();
        } else if(state == TopMenuState.Minimizing) {
            ProgressMinimizing();
        }
    }

    public void OnMouseOver()
    {
        if(state == TopMenuState.Minimized) {
            Maximize();
        }
    }

    private GameObject CreateModeAppItem(AppMode appMode)
    {
        GameObject prefab = Resources.Load<GameObject>(appMode.buttonPrefab);
        GameObject instance = Instantiate(prefab);
        AppModeButton appModeButton = instance.GetComponent<AppModeButton>();
        appModeButton.SetText(LocalizedString.GetLocalizedString(appMode.modeName));
        return instance;
    }

    private void ResetTimeSinceLastMouseOverIfRayCastHit()
    {
        Ray ray = topMenuCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, 1000f);

        foreach(RaycastHit hit in hits) {
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Menu")) {
                timeSinceLastMouseOver = 0f;
                return;
            }
        }
    }

    private void Minimize()
    {
        if(state != TopMenuState.Maximized)
            return;
        state = TopMenuState.Minimizing;
        timeProgressTime = 0f;
    }

    private void Maximize()
    {
        if(state != TopMenuState.Minimized)
            return;
        state = TopMenuState.Maximazing;
        timeProgressTime = 0f;
    }

    private void ProgressMaximazing()
    {
        timeProgressTime += Time.deltaTime * slideSpeed;
        transform.position = Vector3.Slerp(minimizedPosition, maximizedPosition, timeProgressTime);
        if(transform.position == maximizedPosition) {
            state = TopMenuState.Maximized;
            timeSinceLastMouseOver = 0f;
        }
    }

    private void ProgressMinimizing()
    {
        timeProgressTime += Time.deltaTime * slideSpeed;
        transform.position = Vector3.Slerp(maximizedPosition, minimizedPosition, timeProgressTime);
        if(transform.position == minimizedPosition)
            state = TopMenuState.Minimized;
    }
}
