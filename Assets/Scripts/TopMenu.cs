using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMenu : MonoBehaviour {

    public void Update()
    {
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screenPoint.z = 0;
        transform.position = screenPoint;
    }
}
