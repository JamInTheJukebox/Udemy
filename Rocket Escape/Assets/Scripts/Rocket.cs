using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Vector3 RocketPosition;
    private Rigidbody TheRocket;
    public float thrust = 10;
    public float torque = 10;
    private AudioSource AudioPlayer;

    private void Awake()
    {
        TheRocket = GetComponent<Rigidbody>();
        AudioPlayer = GetComponent<AudioSource>();
    }
    void Update ()
    {
        ProcessMoveInput();
        ProcessRotation();
    }

    private void ProcessMoveInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TheRocket.AddRelativeForce(thrust*Vector3.up);
            TheRocket.velocity = Vector3.ClampMagnitude(TheRocket.velocity, 100f);
            print(TheRocket.velocity.magnitude);
            if (!AudioPlayer.isPlaying)
            {
                AudioPlayer.Play();
            }
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            AudioPlayer.Stop();
        }
    }

    private void ProcessRotation()
    {
        TheRocket.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(torque * Vector3.forward * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-torque * Vector3.forward * Time.deltaTime);
        }
        TheRocket.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Ok");
                break;

            case "Fuel":
                print("Add Fuel");
                break;

            case "Danger":
                Destroy(gameObject);
                break;
            default:
                print("IDK");
                break;
        }

    }
}

