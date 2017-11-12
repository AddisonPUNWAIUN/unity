using UnityEngine;

[ExecuteInEditMode]
public class SnapToGround : MonoBehaviour
{

    MapEdit map;
    Vector3 angle;
    void Start()
    {
        map = FindObjectOfType<MapEdit>();
        angle = transform.localEulerAngles;

    }
    void LateUpdate()
    {
        transform.localPosition = GetSnappedPosition(transform.localPosition, map.gridSideLength);
    }

    Vector3 GetSnappedPosition(Vector3 position, float units)
    {
        if (units == 0)  return position;
        Vector3 gridPosition = new Vector3(
            units * Mathf.Round(position.x / units),
            units * Mathf.Round(getGroundHeight() / units),
            units * Mathf.Round(position.z / units)
        );
        return gridPosition;
    }

    float getGroundHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {  return hit.point.y; }
         else if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        { return hit.point.y; }
        else
        { return transform.position.y; }
    }

    
}