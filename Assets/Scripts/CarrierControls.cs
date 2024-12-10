using UnityEngine;
using UnityEngine.UIElements;

public class CarrierControls : MonoBehaviour
{
    //create a new Rigidbody called rb to manipulate in our script
    Rigidbody rb;
    Quaternion righted;

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
        transform.Translate(0,0,Time.deltaTime);

        if (rb.rotation.z != 0f && !Input.anyKeyDown)
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, righted, 0.04f);
        }

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
                if (rb.transform.eulerAngles.z < 30f)
                {
                    rb.transform.eulerAngles.Set(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y, Mathf.Lerp(rb.transform.eulerAngles.z, 30f, 0.5f));
                }   //I don't know what's going on with this code, but it seems to work so I'm just going to stop touching it!
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(thrust, 0f, 0f, ForceMode.Acceleration);
            rb.AddTorque(0f, 0f, -0.5f);
        }
    }
}
