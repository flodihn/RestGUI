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
    private TextMesh[] thisTextMeshes;
    private List<Color> TextMeshOrigColor = new List<Color>();
	private MainMenu mainMenu;

    public void Start()
    {
        mainMenuSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
		mainMenu = transform.parent.GetComponent<MainMenu> ();

        AddAndFitBoxCollider();
        FindAndSetupTextMeshes();
    }

	public void OnMouseDown() {
		Debug.Log (method.ToString() + " " + actionUrl);
		// do post action here.
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
        thisTextMeshes = gameObject.GetComponentsInChildren<TextMesh>();
        foreach(TextMesh textMesh in thisTextMeshes) {
            TextMeshOrigColor.Add(textMesh.color);
        }
    }

    private void HighLight()
    {
        foreach(TextMesh textMesh in thisTextMeshes) {
            textMesh.color = textHighLightColor;
        }
    }

    public void UnHighLight()
    {
        int index = 0;
        foreach(TextMesh textMesh in thisTextMeshes) {
            textMesh.color = TextMeshOrigColor[index];
            index++;
        }
    }
}
