using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuItem : MonoBehaviour
{
	public enum ActionMethod {
		GET,
		POST,
		PUT
	};
	public string actionUrl;
	public ActionMethod method;
    public Color textHighLightColor = Color.green;
    private BoxCollider thisBoxCollider;
    private SpriteRenderer mainMenuSpriteRenderer;
    private TextMesh thisTextMesh;
    private Color TextMeshOrigColor;
	private MainMenu mainMenu;

    public void SetText(string text)
    {
        mainMenuSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        mainMenu = transform.parent.GetComponent<MainMenu>();
        thisTextMesh = GetComponentInChildren<TextMesh>();

        thisTextMesh.text = text;
        AddAndFitBoxCollider();
        FindAndSetupTextMeshes();
    }

	public void OnMouseDown() {
        Debug.Log(method.ToString() + " " + actionUrl);
		mainMenu.HideMainMenu();
	}

    public void OnMouseEnter()
    {
        HighLight();
		mainMenu.MouseOverChildItem = true;
    }

    public void OnMouseExit()
    {
        UnHighLight();
		mainMenu.MouseOverChildItem = false;
    }

    private void AddAndFitBoxCollider()
    {
        thisBoxCollider = gameObject.AddComponent<BoxCollider>();
        thisBoxCollider.size = new Vector3(
                mainMenuSpriteRenderer.size.x, 0.3f, 1);
    }

    private void FindAndSetupTextMeshes()
    {
        TextMeshOrigColor = thisTextMesh.color;
    }

    private void HighLight()
    {
        thisTextMesh.color = textHighLightColor;
    }

    public void UnHighLight()
    {
        thisTextMesh.color = TextMeshOrigColor;
    }
}
