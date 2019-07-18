using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour {

    private bool TouchedGround = false;
    private float GroundLimit = 4.38f; // Anything greater than this is lower than the ground!
    public float GrowSpeed;

    private void Update()
    {
        float ObjectScale = transform.localScale.y;

        if(ObjectScale <= 1)
        {
            TouchedGround = false;
        }
        else if(ObjectScale > GroundLimit)
        {
            TouchedGround = true;
        }


        if (!TouchedGround)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + GrowSpeed * Time.deltaTime, transform.localScale.z);
        }
        else if (TouchedGround)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + -GrowSpeed * Time.deltaTime, transform.localScale.z);
        }

    }

}
