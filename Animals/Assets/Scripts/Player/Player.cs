using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float turnSpeed = 12f;
    public float jumpPower = 10f;
    public bool isGrounded = false;
    Vector3 movement = Vector3.zero;
    Vector3 jump = Vector3.zero;
    Quaternion direction = Quaternion.identity;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveAndJump(int control, float x,float h, float v,bool j)
    {

        #region Check Gound
        RaycastHit bodyHit;
#if UNITY_EDITOR
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * 0.5f));
#endif
        if (Physics.Raycast(transform.position, Vector3.down, out bodyHit, 0.5f))
            isGrounded = true;
        else
            isGrounded = false;
        #endregion

        #region Move And Jump
        if (control == 0)
        {
            Quaternion viewDir = Quaternion.Euler(0, x, 0);
            movement = viewDir * (Vector3.forward * v + Vector3.right * h);
        }
        else if (control == 1 || control == 2)
            movement.Set(h, 0f, v);
        else
            movement = transform.right * h + transform.forward * v;
        movement = movement.normalized * speed * Time.fixedDeltaTime;
        if (isGrounded)
        {           
            if (j)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
                jump = movement.normalized * speed * 0.5f * Time.fixedDeltaTime;
            }
            rb.MovePosition(transform.position + movement);
        }
        else
        {
            if (movement != Vector3.zero)
                rb.MovePosition(transform.position + movement);
            else
                rb.MovePosition(transform.position + jump);
        }
        #endregion

        #region Turning
        if (control == 0)
        {
            if (movement != Vector3.zero)
                direction = Quaternion.RotateTowards(direction,
                            Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z)),
                            isGrounded ? turnSpeed : turnSpeed / 2);
        }
        else if ( control == 1)
        {
            if (h != 0 || v != 0)
                direction = Quaternion.RotateTowards(direction, 
                            Quaternion.LookRotation(new Vector3(h, 0, v)),
                            isGrounded ? turnSpeed : turnSpeed / 2);
        }
        else if (control == 2 || control == 3)
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;
            if (Physics.Raycast(camRay, out floorHit, Camera.main.farClipPlane))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0f;
                direction = Quaternion.RotateTowards(direction,
                            Quaternion.LookRotation(playerToMouse),
                            isGrounded ? turnSpeed : turnSpeed / 2);
            }
        }
        rb.MoveRotation(direction);
        #endregion

    }

}