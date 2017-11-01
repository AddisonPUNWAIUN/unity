using UnityEngine;
using UnityEngine.SceneManagement;


public class Boat : MonoBehaviour
{
    public float speed = 1;
    [Range(0, 180)] public int fallAngle = 60;
    public bool isFloating = false;
    public bool canControl = true;
    public bool holding = false;
    Ocean ocean;
    Rigidbody rb;
    Vector3 moveDirection = Vector3.zero;
    Quaternion direction = Quaternion.identity;

    void Start()
    {
        ocean = FindObjectOfType<Ocean>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(!canControl)        
        {
            SceneManager.LoadScene("Ocean");
        }
    }
    void FixedUpdate ()
    {
        Drifting();
    }
    public void Balance(bool b)
    {
        if (Mathf.Abs(Mathf.DeltaAngle(0, transform.eulerAngles.z)) > fallAngle)
        {
            transform.Find("driver").parent = null;
            canControl = false;
        }
        if (b)
        {
            holding = true;
            rb.centerOfMass = Vector3.zero;
        }
        else
        {
            holding = false;
            rb.centerOfMass = transform.Find("COM").localPosition;
        }
        moveDirection.y += Physics.gravity.y * Time.fixedDeltaTime;
    }
    void Drifting()
    {
        if (isFloating && !holding)
            rb.velocity = new Vector3(ocean.waveX, 0, ocean.waveZ) * -ocean.waveSpeed;
        moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, Time.fixedDeltaTime);
    }

    public void Move(float h, float v, float pow)
    {
        if (!holding && isFloating)
        {
            if (h != 0 || v != 0)
            {
                moveDirection = Vector3.Lerp(moveDirection, new Vector3(h,0,v) * pow, Time.fixedDeltaTime * speed);
                direction = Quaternion.LookRotation(new Vector3(h, 0, v));
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, speed);
            float moveFactor = 1 - Quaternion.Angle(transform.rotation, direction) / 210;          
        }
        rb.MovePosition(moveDirection * Time.fixedDeltaTime + rb.position);
        if (holding)
        {
            if (h != 0 || v != 0)
                direction = Quaternion.LookRotation(new Vector3(h, 0, v));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, speed);
            if (Mathf.DeltaAngle(90, transform.eulerAngles.y) < 0)
                transform.Rotate(0, 0, -h * 3f);
            else
                transform.Rotate(0, 0, h * 3f);
        }
    }
}
