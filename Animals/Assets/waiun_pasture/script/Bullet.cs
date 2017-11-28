using UnityEngine;
using System.Collections;
 
public class Bullet : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        gameObject.transform.position += new Vector3(0, 0.2f, 0.5f);
 
    }
}