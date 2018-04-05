using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuItem : MonoBehaviour
{
    public Color textHighLightColor = Color.green;
    private BoxCollider thisBoxCollider;
    private SpriteRenderer mainMenuSpriteRenderer;
    private TextMesh[] thisTextMeshes;
    private List<Color> TextMeshOrigColor = new List<Color>();

    public void Start()
    {
        mainMenuSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();

        AddAndFitBoxCollider();
        FindAndSetupTextMeshes();
    }

    public void OnMouseEnter()
    {
        HighLight();
    }

    public void OnMouseExit()
    {
        UnHighLight();
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

    private void UnHighLight()
    {
        int index = 0;
        foreach(TextMesh textMesh in thisTextMeshes) {
            textMesh.color = TextMeshOrigColor[index];
            index++;
        }
    }
}
