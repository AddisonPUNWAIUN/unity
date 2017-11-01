using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrains : MonoBehaviour
{
    [SerializeField]
    protected Vector3 gravity = new Vector3(0, -20f, 0);

    void Awake()
    {
        Physics.gravity = gravity;
    }
}
