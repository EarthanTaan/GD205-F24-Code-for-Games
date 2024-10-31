using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    // An array of Transforms called 'myHazards'. 
    public Transform[] myHazards;

    // An array of Transforms called 'walkables'. In the editor this array has been populated with the floor cubes. (Incidentally, those cubes are also all tagged: 'Walkable',
    // but I don't know how to utilize that.)
    public Transform[] walkables;

    // 'Vector3' is a variable that contains a 3D vector coordinate in the form of (x, y, z).
    Vector3 startPos;

    // Declare a new variable of datatype 'AudioSource' with the name "dortSound"
    AudioSource dortSound;

    void Start()
    {
        // Define the startPos as being the position the player is in when the game begins.
        startPos = transform.position;

        //Assign variable the value taken from the AudioSource Component attached to the assigned GameObject. (Note: "this" refers to this script, not the gameObject)
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