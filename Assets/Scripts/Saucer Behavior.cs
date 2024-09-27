using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerBehavior : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }
        //if (Input.GetKey(KeyCode.W)) 
        //{
        //    rb.velocity += 1f;
        //}
    }
}
