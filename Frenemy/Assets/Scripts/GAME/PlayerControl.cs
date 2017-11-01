using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Player))]

public class PlayerControl : MonoBehaviour
{
    public enum MoveMethod { Move1, Move2, Rowing };
    public bool mobile;
    public MoveMethod moveMethod;
    Player player;
    float h, v;
    bool j;

    void Start ()
    {
        player = GetComponent<Player>();
    }
	
	void Update ()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        j = Input.GetButton("Jump") || CrossPlatformInputManager.GetButton("Action");

        if (mobile)
        {
            h = CrossPlatformInputManager.GetAxis("Horizontal");
            v = CrossPlatformInputManager.GetAxis("Vertical");
        }
    }

    void FixedUpdate()
    {
        if (moveMethod == MoveMethod.Rowing)
            player.Rowing(h, v, j);
        else if (moveMethod == MoveMethod.Move1)
            player.Move1(h, v, j);
        else if (moveMethod == MoveMethod.Move2)
            player.Move2(h, v, j);
    }
}
