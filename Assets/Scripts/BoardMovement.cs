using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    public Transform myHazard;
    //public int myInt = 5;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.back;
        }

        if (transform.position == myHazard.position)
        {
            Debug.Log("BOOM");
            transform.position = startPos;
        }
    }
}