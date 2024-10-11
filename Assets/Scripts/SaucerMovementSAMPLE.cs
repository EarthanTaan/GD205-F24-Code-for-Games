using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerMovement : MonoBehaviour
{
    //create a new Rigidbody called rb to manipulate in our script
    Rigidbody rb;

    //make a new public variable to change our acceleration force
    public float acc = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //assign RB using GetComponent (the rigidbody attached to this gameobject)
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(rb.GetComponent<Collider>(), rb.GetComponent<Collider>(), true);
    }

    // FixedUpdate is called once per standard interval instead of per frame
    void FixedUpdate()
    {
        //same as our previous script except using getkey since we want it to apply continuously if its being pressed down, not just for one frame
        if (Input.GetKey(KeyCode.W)){
            //we are using the AddForce method in the appropriate direction using our variable
            rb.AddRelativeForce(0f, 0f, acc, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S)){
            rb.AddRelativeForce(0f, 0f, -acc, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A)){
            rb.AddRelativeTorque(0f, -acc * 0.33f, 0f, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D)){
            rb.AddRelativeTorque(0f, acc * 0.33f, 0f, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.E)){
            rb.AddRelativeForce(acc, 0f, 0f, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Q)){
            rb.AddRelativeForce(-acc, 0f, 0f, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
    }

    //OnCollisionEnter is a built in function that will run whenever this objects collider hits another one
    //and at least one of those objects has a rigidbody attached

    void OnCollisionEnter(Collision col){ //when running this, it will create a new Collision object that tracks all the information about the collision that just happened
        //Destroy(gameObject); //run the destroy method on the gameObject this script is attached to
    }
}
