using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipAndDrag : MonoBehaviour
{
    private RectTransform _rectTransform;
    private float timeSinceLastClick = 0.0f;
    private Vector3 dragOffset;
    private int clicks = 0;
    private float flipDeltaAngle = 0f;

    private Transform front;
    private Transform back;

    private bool flippedContent = false;

    public enum FlipState
    {
        FRONT,
        BACK
    }
    
    public enum ClickState
    {
        None,
        Drag,
        Flip
    };

    public ClickState clickState = ClickState.None;
    public FlipState flipState = FlipState.FRONT;

    public void Start()
    {
        front = transform.Find("Front");
        back = transform.Find("Back");

        ShowFront();
        HideBack();
    }

    public void OnMouseDown()
    {
        timeSinceLastClick = 0.2f;
        clicks += 1;

        if(clicks == 1) {
            SetDragOffset();
        }

        if(clicks == 2) {
            clickState = ClickState.Flip;
        }
    }

    void Update()
    { 
        if(clickState == ClickState.None) {
            DoIdle();
        } else if(clickState == ClickState.Drag) {
            DoDrag();
        } else if(clickState == ClickState.Flip) {
            DoFlip();
        }
    }

    private void DoIdle()
    {
        if(timeSinceLastClick > 0f) {
            timeSinceLastClick -= Time.deltaTime;
        }
        if(timeSinceLastClick <= 0f) {
            if(clicks == 1) {
                clickState = ClickState.Drag;
            }
            clicks = 0;
        }
    }

    private void SetDragOffset()
    {
        Vector3 screenPointOffset = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        screenPointOffset = Camera.main.ScreenToWorldPoint(screenPointOffset);
        dragOffset = transform.position - screenPointOffset;
        dragOffset.z = 0;
    }

    private void DoDrag()
    { 
        if(!Input.GetMouseButton(0)) {
            ResetState();
            return;
        }

        Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        screenPoint.z = transform.position.z - Camera.main.transform.position.z;
        screenPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        transform.position = screenPoint + dragOffset;
    }

    private void DoFlip()
    {
        float flipAmount = Time.deltaTime * 1000;


        if(!flippedContent && flipDeltaAngle > 90) {
            FlipConent();
            flippedContent = true;
        }

        if(flipDeltaAngle + flipAmount > 180.0f) {
            flipAmount = 180.0f - flipDeltaAngle;
        }

        transform.Rotate(new Vector3(0, flipAmount, 0));
        flipDeltaAngle += flipAmount;

        if(flipDeltaAngle == 180.0f) {
            ResetState();
            if(flipState == FlipState.FRONT) {
                flipState = FlipState.BACK;
            } else if(flipState == FlipState.BACK) {
                flipState = FlipState.FRONT;
            }
        }
    }

    private void ResetState()
    {
        clickState = ClickState.None;
        flipDeltaAngle = 0f;
        clicks = 0;
        timeSinceLastClick = 0f;
        dragOffset = Vector3.zero;
        flippedContent = false;
    }

    private void FlipConent()
    {
        if(flipState == FlipState.FRONT) {
            HideFront();
            ShowBack();
        } else if(flipState == FlipState.BACK) {
            ShowFront();
            HideBack();
        }
    }

    private void HideFront()
    {
        foreach(Transform child in front) {
            child.gameObject.SetActive(false);
        }
    }

    private void ShowFront()
    {
        foreach(Transform child in front) {
            child.gameObject.SetActive(true);
        }
    }

    private void HideBack()
    {
        foreach(Transform child in back) {
            child.gameObject.SetActive(false);
        }
    }

    private void ShowBack()
    {
        foreach(Transform child in back) {
            child.gameObject.SetActive(true);
        }
    }
}
