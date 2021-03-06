﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTrigger : MonoBehaviour {
    private  MainMenu mainMenu;

    public void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>();
        mainMenu.HideMainMenu();
    }

    void OnMouseDown()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hitInfo, 100f, LayerMask.GetMask("Background"), QueryTriggerInteraction.Collide)) {
            if(hitInfo.transform == transform) {
                mainMenu.ShowMainMenu();
            }
        }
    }
}
