using UnityEngine;
using UnityEngine.UIElements;

public class CarrierControls : MonoBehaviour
{
    //create a new Rigidbody called rb to manipulate in our script
    Rigidbody rb;
    Quaternion righted = new Quaternion();

    //make a new public variable to change our acceleration force
    public float thrust = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Physics.IgnoreCollision(rb.GetComponent<Collider>(), rb.GetComponent<Collider>(), true); //I don't think I need this

        righted = rb.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (rb.rotation.z != 0f && !Input.anyKeyDown)
        //{
            rb.rotation = Quaternion.Slerp(rb.rotation, righted, 0.04f);
        //}

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0f, 0f, thrust, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0f, 0f, -thrust, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-thrust, 0f, 0f, ForceMode.Force);
                if (rb.rotation.z < 30f)
                {
                    rb.AddTorque(0f, 0f, 0.5f, ForceMode.Force);    //for some reason, this line of code is also giving me the same behavior on the opposite side. If it ain't broke I won't fix it.
                }
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(thrust, 0f, 0f, ForceMode.Force);
            rb.AddTorque(0f, 0f, -0.5f);
        }
    }
}
