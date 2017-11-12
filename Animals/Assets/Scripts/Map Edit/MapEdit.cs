using UnityEngine;

public class MapEdit : MonoBehaviour
{
    public float gridSideLength = 1;
    public int grideAngle = 90;
    public LayerMask groundLayer;
    public LayerMask objectLayer;

    Ray ray;
    RaycastHit objectHit, groundHit;
    Vector3 click, offset;

    public bool ClickObject()
    {
        click = Input.mousePosition;
        if (GetHit(groundLayer) && GetHit(objectLayer))
        {
            offset = groundHit.point - objectHit.transform.position;
            return true;
        }
        return false;
    }
    public void DragObject()
    {
        if (Vector3.Distance(click, Input.mousePosition) > 5)
        {           
            if (GetHit(groundLayer))
                objectHit.transform.position = groundHit.point - offset; 
        }
    }
    public void DestroyObject()
    {
        if (GetHit(objectLayer))
            Destroy(objectHit.transform.gameObject);
    }
    public void RotateObject()
    {
        if (GetHit(objectLayer))
            objectHit.transform.eulerAngles += Vector3.up * 90;
    }
    bool GetHit(LayerMask layer)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (layer == objectLayer)
            return Physics.Raycast(ray, out objectHit, Mathf.Infinity, layer);
        else if (layer == groundLayer)
            return Physics.Raycast(ray, out groundHit, Mathf.Infinity, layer);
        return false;
    }
}

