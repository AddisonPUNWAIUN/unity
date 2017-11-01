using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminalTrigger : MonoBehaviour
{
    public string scene;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            SceneManager.LoadScene(scene);
        }
    }
}
