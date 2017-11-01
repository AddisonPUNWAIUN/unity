using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float turnSpeed = 1f;
    public float rowPower = 6f;
    Vector3 moveDirection = Vector3.zero;
    Quaternion direction = Quaternion.identity;
    public bool isGrounded;
    CharacterController controller;
    Boat boat;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        boat = FindObjectOfType<Boat>();
    }
    
    public void Move1(float h, float v, bool j)
    {
        if (controller.isGrounded)
        {
            this.isGrounded = true;
            moveDirection.Set(h, 0, v);
            moveDirection *= speed;
            if (j)
                moveDirection.y = jumpSpeed;
        }
        else isGrounded = false;
        moveDirection.y += Physics.gravity.y * Time.fixedDeltaTime;
        controller.Move(moveDirection * Time.fixedDeltaTime);
        if (h != 0 || v != 0)
        {
            direction = Quaternion.LookRotation(new Vector3(h, 0, v));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, turnSpeed );
        }
    }
    public void Move2(float h, float v, bool j)
    {
        if (controller.isGrounded)
        {
            this.isGrounded = true; 
            moveDirection = Vector3.Lerp(moveDirection, new Vector3(h, 0, v)* speed, Time.fixedDeltaTime);
            if (j)
                moveDirection.y = jumpSpeed;
        }
        else isGrounded = false;
        moveDirection.y += Physics.gravity.y * Time.fixedDeltaTime;
        controller.Move(moveDirection * Time.fixedDeltaTime);
        if (h != 0 || v != 0)
        {
            direction = Quaternion.LookRotation(new Vector3(h, 0, v));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, turnSpeed);
        }
    }
    
    public void Rowing(float h, float v, bool j)
    {
        if (boat.canControl&&boat)
        {
            boat.Move(h, v, rowPower);
            boat.Balance(j);
        }
    }
}
