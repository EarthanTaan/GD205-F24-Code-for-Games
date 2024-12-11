using UnityEngine;
using UnityEngine.UIElements;

public class CarrierControls : MonoBehaviour
{
    //create a new Rigidbody called rb to manipulate in our script
    Rigidbody rb;
    Quaternion righted;

    //make a new public variable to change our acceleration force (this becomes accessible from the editor side, in the component)
    public float thrust = 50f;
    public float roll = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //righted = rb.rotation;        //abandoning this goal but leaving the scaffold, such as it is, in case I want to revisit this laeet
    }

    void FixedUpdate()
    {
        transform.Translate(0,0,Time.deltaTime);

        //if (rb.rotation.z != 0f && !Input.anyKeyDown)
        //{
        //    rb.rotation = Quaternion.Slerp(rb.rotation, righted, 0.04f);
        //}

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0f, 0f, thrust, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0f, 0f, -thrust, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-thrust, 0f, 0f, ForceMode.Acceleration);
            //if (transform.eulerAngles.z < 30f)
            //{
            //    transform.Rotate(transform.position.x, transform.position.y, transform.position.z + roll);        //I want to roll the ship to the left as it banks leftward, but I can't find he magic words.
                    //gotta abandon this bit, it's not working and it's not vital. Code not deleted for posterity and maybe later I'll understand what happened and be able to fix it.
            //}
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(thrust, 0f, 0f, ForceMode.Acceleration);
        }
    }
}
