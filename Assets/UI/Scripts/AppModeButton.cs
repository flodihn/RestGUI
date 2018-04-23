using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AppSystem.Models;

public class AppModeButton : MonoBehaviour {
    public AppMode appMode;
    private TextMesh textMesh;
    private SpriteRenderer spriteRenderer;
    private Color origColor;
    private MainMenu mainMenu;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        origColor = spriteRenderer.color;
    }

    public void OnMouseDown()
    {
        Debug.Log("AppModeItem OnMouseDown");
        SystemApp.SelectAppMode(appMode);
        if(mainMenu == null) {
            foreach(MainMenu foundObject in Resources.FindObjectsOfTypeAll(typeof(MainMenu))) {
                mainMenu = foundObject;
            }
        }
        mainMenu.AddMenuItems();
    }

    public void OnMouseEnter()
    {  
        spriteRenderer.color = new Color(
            origColor.r,
            origColor.g,
            origColor.b,
            origColor.a * 2);
    }

    public void OnMouseExit()
    {
        spriteRenderer.color = origColor;
    }

    public void SetText(string text)
    {
        if(textMesh == null)
            textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = text;
    }
}
