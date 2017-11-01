using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloating : MonoBehaviour
{
    Boat boat;
    void Start()
    {
        boat = GetComponentInParent<Boat>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
            boat.isFloating = true;
    }
    void OnTriggerExit(Collider other)
    {
        boat.isFloating = false;
    }
}
