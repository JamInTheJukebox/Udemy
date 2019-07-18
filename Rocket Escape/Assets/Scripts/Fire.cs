using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameObject FireVFX;
    ParticleSystem.MainModule FireEffects;
    private void Awake()
    {

        FireVFX = transform.Find("Fire").gameObject;

        FireEffects = FireVFX.GetComponent<ParticleSystem>().main;
        FireEffects.loop = false;
        FireVFX.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Fire_Effects();
            FireVFX.SetActive(true);
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Turn_Off_Fire_Effects();
        }
    }
    private void Fire_Effects()
    {
        FireEffects.loop = true;
        FireVFX.GetComponent<ParticleSystem>().Play();
    }
    private void Turn_Off_Fire_Effects()
    {
        FireEffects.loop = false;
    }
}
