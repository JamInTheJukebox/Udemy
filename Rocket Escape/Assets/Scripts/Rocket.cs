using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Vector3 RocketPosition;
    private Rigidbody TheRocket;
    public float thrust = 10;
    public float torque = 10;
    private void Awake()
    {
        TheRocket = GetComponent<Rigidbody>();
    }
    void Update ()
    {
        ProcessInput();

    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TheRocket.AddRelativeForce(thrust*Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(torque* Vector3.forward * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("TUrn Right");
            transform.Rotate(-torque * Vector3.forward * Time.deltaTime);

        }
    }
}
