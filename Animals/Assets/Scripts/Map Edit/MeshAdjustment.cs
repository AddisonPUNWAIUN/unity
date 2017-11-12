using UnityEngine;

[ExecuteInEditMode]
public class MeshAdjustment : MonoBehaviour
{
    BoxCollider col;
	void Start ()
    {
        col = transform.parent.GetComponent<BoxCollider>();
    }
	
	void Update ()
    {
        transform.localPosition = col.center;
    }
}
