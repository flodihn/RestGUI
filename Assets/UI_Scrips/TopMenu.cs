using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMenu : MonoBehaviour
{
    public string minmizedText;
    public float minimizedHeightOffset;
    private RectTransform minimizePosition;
    private RectTransform expandedPosition;

    public enum TopMenuState {
        Minimized,
        Expanded
    }

    public TopMenuState state;

    public void Start()
    {
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height, 0));
        screenPoint.z = 0;
        screenPoint.y += minimizedHeightOffset;
        transform.position = screenPoint;
        state = TopMenuState.Minimized;
    }

    public void Minimize()
    {
    }

    public void Expand() {
        
    }

}
