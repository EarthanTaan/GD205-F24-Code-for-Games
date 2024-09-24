using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    public Transform[] myHazards;
    public Transform[] walkables;
    

    // 'Vector3' is a variable that contains a 3D vector coordinate in the form of (x, y, z).
    Vector3 startPos;

    // Declare a new variable of datatype 'AudioSource' with the name "dortSound":
    AudioSource dortSound;

    void Start()
    {
        startPos = transform.position;
        //Assign variable the value taken from the AudioSource Component attached to 'this' GameObject:
        dortSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //if (transform.position == walkables.position)
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

        //if (transform.position == myHazards.position)
        //{
        //    Debug.Log("BOOM");
        //    transform.position = startPos;
        //}


    }
}