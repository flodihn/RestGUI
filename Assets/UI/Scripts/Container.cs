using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public float horziontalSpacing = 0.3f;

    public void AddItem(GameObject item)
    {
        item.transform.SetParent(transform, false);
        RepositionChildren();
    }

    protected void RepositionChildren()
    {
        float totalWidth = GetTotalWidth();
        float averageChildWidth = GetAverageChildWidth();
        float currentWidth = -(totalWidth / 2) + (averageChildWidth / 2);
        int childIndex = 0;
        foreach(Transform child in transform) {
            SetChildPositionAtIndex(child, childIndex, ref currentWidth);
            childIndex++;
        }
    }

    private float GetTotalWidth()
    {
        float totalWidth = 0f;
        foreach(Transform child in transform) {
            SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();

            if(childSpriteRenderer == null)
                continue;

            totalWidth += childSpriteRenderer.size.x + horziontalSpacing;
        }
        return totalWidth;
    }

    public float GetAverageChildWidth()
    {
        float totalWidth = GetTotalWidth();
        return totalWidth / transform.childCount;
    }

    public void SetChildPositionAtIndex(Transform child, int index, ref float currentWidth)
    {
        child.localPosition = new Vector3(
            currentWidth,
            0f,
            transform.position.z - 0.01f);

        currentWidth += child.GetComponent<SpriteRenderer>().size.x + horziontalSpacing;
    }
}
