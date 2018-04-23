using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AppSystem.Models;

public class MainMenu : MonoBehaviour
{
    public bool MouseOverChildItem = false;

    private SpriteRenderer thisSpriteRenderer;
    private bool mouseOverMainMenu = false;
    private List<MainMenuItem> items = new List<MainMenuItem>();
    private Camera menuCamera;

    public void Awake()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.size = thisSpriteRenderer.size;
    }

    public void LateUpdate()
    {
        if(mouseOverMainMenu)
            return;
        if(MouseOverChildItem)
            return;
        HideMainMenu();
    }

    public void AddMenuItems()
    {
        if(SystemApp.SelectedAppMode == null)
            return;

        foreach(MainMenuItem menuItem in items) {
            GameObject.Destroy(menuItem.gameObject);
        }

        items.Clear();
        GameObject menuItemPrefab = Resources.Load("UI/MainMenu/MenuItem") as GameObject;
        AppSystem.Models.MainMenu mainMenu = SystemApp.RestAPI.GetMainMenu();
        foreach(AppSystem.Models.MainMenuItem menuItemModel in mainMenu.mainMenuItems) {
            GameObject instance = Instantiate(menuItemPrefab);
            instance.transform.SetParent(transform, false);
            MainMenuItem mainMenuItem = instance.GetComponent<MainMenuItem>();
            mainMenuItem.SetText(LocalizedString.GetLocalizedString(menuItemModel.itemName));
            mainMenuItem.actionUrl = menuItemModel.url;
            items.Add(mainMenuItem);
        }
        SetSortOrder();
        ArrangeItems();
    }

    public void ShowMainMenu()
    {
        mouseOverMainMenu = true;
        if(menuCamera == null)
            menuCamera = GameObject.FindGameObjectWithTag("MenuCamera").GetComponent<Camera>();

        Vector3 position = menuCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 1;
        transform.position = position;
        transform.Translate(new Vector3(0, (-thisSpriteRenderer.size.y / 2) + 0.2f, 0));
        gameObject.SetActive(true);
    }

    public void HideMainMenu()
    {
        gameObject.SetActive(false);
        if(items != null) {
            foreach(MainMenuItem item in items) {
                item.UnHighLight();
            }
        }
    }

    private void ArrangeItems()
    {
        float currentY = 1f;
        foreach(Transform child in transform) {
            child.localPosition = new Vector3(-0.75f, currentY, 0);
            currentY -= 0.3f;
        }
    }

    public void OnMouseOver()
    {
        mouseOverMainMenu = true;
    }

    public void OnMouseExit()
    {
        mouseOverMainMenu = false;
    }

    private void SetSortOrder()
    {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
        foreach(Transform child in allChildren) {
            Renderer textRenderer = child.GetComponent<Renderer>();
            if(textRenderer != null) {
                textRenderer.sortingOrder = thisSpriteRenderer.sortingOrder + 1;
            }
        }
    }
}
