using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    Vector3 pos, rot;
    Vector3 newPos,newRot;
    bool move = false,choose = false;
 
    void Start()
    {
        pos = transform.localPosition;
        rot = transform.localEulerAngles;
    }
    void Update()
    {
        if (Wilderness.crack && !move)
        {
           getNewPos();
            move = true;
        }
        if(!Wilderness.crack && move)
        {
            move = false;
        }
    }
    void FixedUpdate()
    {
        if ( move&&choose)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPos, 0.1f);
        }
	}
    void getNewPos()
    {
        float x, y, z;
        x = Random.Range(-10, 10);
        y = Random.Range(0, 2);
        z = Random.Range(-10, 10);
        newPos = new Vector3(x, y, z) + pos;

        if (Random.value <= 0.7)
        {
            choose = true;          
        }
    }
}
