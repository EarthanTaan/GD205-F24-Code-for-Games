using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    //public Transform myHazard; (rendered obsolete by the following array)
    public Transform[] myHazards;

    //public int myInt = 5;
    Vector3 startPos;

    //Declare a new variable of datatype 'AudioSource' with a name:
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

        //if (transform.position == myHazard.position)
        //{
        //    Debug.Log("BOOM");
        //    transform.position = startPos;
        //}

        for (int howManyTimesLoopHasRun = 0; howManyTimesLoopHasRun < myHazards.Length; howManyTimesLoopHasRun++)
        {
            if (transform.position == myHazards[howManyTimesLoopHasRun].position)
            {
                //Take the AudioSource referred to by the variable and execute its Play function:
                dortSound.Play();
                Debug.Log("BOOM!");
                transform.position = startPos;
            }
        }
    }
}