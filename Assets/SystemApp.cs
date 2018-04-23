using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AppSystem.RestAPI;
using AppSystem.Models;

public class SystemApp : MonoBehaviour {
    public static IRestAPI RestAPI;
    public static string LanguageCode = "EN";
    public static AppMode SelectedAppMode;

    public void Start()
    {
        if(RestAPI == null)
            RestAPI = new FakeRestAPI();
    }

    public static void SelectAppMode(AppMode appMode)
    {
        SelectedAppMode = appMode;
        Debug.Log("Selected AppMode: " + appMode.mode);
    }
}
