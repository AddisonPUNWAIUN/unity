using UnityEngine;
using System.Collections;
 
public class Bullet : MonoBehaviour
{
    public float speed=30;

    void Start()
    {

    }
    void Update()
    {
        //gameObject.transform.position += new Vector3(0, 0.2f, 0.5f);
        //gameObject.transform.Translate(0, 0,speed* Time.deltaTime,Space.Self);
 
    }
    private void FixedUpdate()
    {
        gameObject.transform.Translate(0, 0, speed * Time.fixedDeltaTime, Space.Self);
    }
}