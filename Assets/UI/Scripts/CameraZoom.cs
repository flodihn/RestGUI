using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    private Camera thisCamera;

    public void Start()
    {
        thisCamera = GetComponent<Camera>();
    }
    void Update () {
        float zoomAmount = (thisCamera.orthographicSize * thisCamera.orthographicSize) * 0.1f;
        thisCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomAmount;
        if(thisCamera.orthographicSize < 1f)
            thisCamera.orthographicSize = 1f;

        if(thisCamera.orthographicSize > 80f)
            thisCamera.orthographicSize = 80f;

    }
}
