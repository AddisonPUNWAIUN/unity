using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFire : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire")
        {
            SceneManager.LoadScene("Volcano");
         }
    }
}
