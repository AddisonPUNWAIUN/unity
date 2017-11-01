using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float start_z, terminal_z;
    public Vector3 offset;
	
	void Update ()
    {
        if (target)
        {
            transform.position = new Vector3(transform.position.x, offset.y, target.position.z + offset.z);
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, start_z, terminal_z));
            Vector3 targetToScreen = Camera.main.WorldToScreenPoint(target.position);
            Vector3 l = Camera.main.ScreenToWorldPoint(new Vector3(0, targetToScreen.y, targetToScreen.z));
            Vector3 r = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, targetToScreen.y, targetToScreen.z));
            target.position = new Vector3(Mathf.Clamp(target.position.x, l.x, r.x), target.position.y, target.position.z);
        }
    }
}
