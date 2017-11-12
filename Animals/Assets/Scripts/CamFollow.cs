using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 8;
    public float height = 10;
    //public float distanceDamping;
    public float heightDamping;
    public float moveSpeed = 2;
    void LateUpdate()
    {
        //if () SmoothFollow(target,height,distance);
    }
    public void MouseView(Transform obj,float x,float y, float d)
    {       
        Cursor.visible = false;
        Quaternion euler = Quaternion.Euler(y, x, 0);
        transform.rotation = euler;
        transform.position = euler * Vector3.forward * -d + obj.position;
    }
    public void SmoothFollow(Vector3 obj, float h, float d, bool follow,bool lookAt)
    {
        Cursor.visible = true;
        if (follow)
        {
            Vector3 newPos = Quaternion.identity * Vector3.forward * -d + obj;
            newPos.y = Mathf.Lerp(transform.position.y, obj.y + h, (1 + heightDamping) * Time.deltaTime);
            transform.position = newPos;
        }
        if(lookAt)
            transform.LookAt(obj);
    }

}
