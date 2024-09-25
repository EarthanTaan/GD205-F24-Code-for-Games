using System.Collections;
using System.Collections.Generic;
using System.Net;
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
            for (int i = 0; i < walkables.Length; i++)
            {
                if (transform.position + new Vector3(-1, -0.75f, 0) == walkables[i].position)
                {
                    transform.position += Vector3.left;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < walkables.Length; i++)
            {
                if (transform.position + new Vector3(1, -0.75f, 0) == walkables[i].position)
                {
                    transform.position += Vector3.right;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < walkables.Length; i++)
            {
                if (transform.position + new Vector3(0, -0.75f, 1) == walkables[i].position)
                {
                    transform.position += Vector3.forward;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < walkables.Length; i++)
            {
                if (transform.position + new Vector3(0, -0.75f, -1) == walkables[i].position)
                {
                    transform.position += Vector3.back;
                }
            }
        }

        for (int i = 0; i < myHazards.Length; i++) {
            if (transform.position == myHazards[i].position)
            {
                dortSound.Play();
                Debug.Log("BOOM");
                transform.position = startPos;
            }
        }

    }
}