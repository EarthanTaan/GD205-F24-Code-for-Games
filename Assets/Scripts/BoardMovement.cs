using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    public Transform hazard;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (condition == true) { do the thing; }
        //in this case, if the GetKeyDown() method of the Input class is true
        //using this argument
        if (Input.GetKeyDown("right"))
        {
            //modify the position property of the transform of the same game object this script is attached to
            //add an offset of 1 unit on the x axis
            transform.position += Vector3.right;
        }
        if (Input.GetKeyDown("left"))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown("up"))
        {
            transform.position += Vector3.forward;
        }
        if (Input.GetKeyDown("down"))
        {
            transform.position += Vector3.back;
        }

    }
}