using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public bool MouseOverChildItem = false;

	private float height;
    private SpriteRenderer thisSpriteRenderer;
	private bool mouseOverMainMenu = false;
	private MainMenuItem[] items;

    public void Start()
    {
		items = GetComponentsInChildren<MainMenuItem>();
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider collider = GetComponent<BoxCollider>();
        height = thisSpriteRenderer.size.y;
        collider.size = thisSpriteRenderer.size;

        SetSortOrder();
        ArrangeItems();
    }

	public void LateUpdate() {
		if (mouseOverMainMenu)
			return;
		if (MouseOverChildItem)
			return;
		HideMainMenu();
	}

    public void ShowMainMenu()
    {
		mouseOverMainMenu = true;
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 1;
        transform.position = position;
        transform.Translate(new Vector3(0, (-height / 2) + 0.2f , 0));
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

	public void OnMouseOver() {
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
