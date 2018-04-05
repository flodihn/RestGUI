using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    private float height;

    private SpriteRenderer thisSpriteRenderer;

    public void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider collider = GetComponent<BoxCollider>();
        height = thisSpriteRenderer.size.y;
        collider.size = thisSpriteRenderer.size;

        SetSortOrder();
        ArrangeItems();
    }

    public void ShowMainMenu()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 1;
        transform.position = position;
        transform.Translate(new Vector3(0, (-height / 2) + 0.2f , 0));
        gameObject.SetActive(true);
    }

    public void HideMainMenu()
    {
        gameObject.SetActive(false);
    }

    private void ArrangeItems()
    {
        float currentY = 1f;
        foreach(Transform child in transform) {
            child.localPosition = new Vector3(-0.75f, currentY, 0);
            currentY -= 0.3f;
        }
    }

    /*
    public void OnMouseExit()
    {
        HideMainMenu();
    }
    */

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
