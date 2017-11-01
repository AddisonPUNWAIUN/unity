using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{

    ParticleSystem smokePs,flamePs;

	void Start ()
    {
        smokePs = transform.Find("Smoke").GetComponent<ParticleSystem>();
        smokePs.Play();
        Invoke("Flame", smokePs.main.duration);  
	}
    void Flame()
    {
        flamePs = transform.Find("Flame").GetComponent<ParticleSystem>();
        flamePs.transform.GetComponent<CapsuleCollider>().enabled = true;
        flamePs.Play();
        Destroy(gameObject, flamePs.main.duration);
    }

}
