using UnityEngine;
using UnityEngine.UIElements;

public class CarrierControls : MonoBehaviour
{
    //create a new Rigidbody called rb to manipulate in our script
    Rigidbody rb;
    Vector3 righted;

    //make a new public variable to change our acceleration force (this becomes accessible from the editor side, in the component)
    public float thrust = 50f;
    public float roll = 35f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        righted = transform.eulerAngles;        //grab the Vector3 for when the ship is at neutral rotation
    }

    void FixedUpdate()
    {
        transform.Translate(0,0,Time.deltaTime * 3f);       // "At rest", the ship moves forward constantly at a slow pace.

        if (transform.eulerAngles.z != 0f && !Input.anyKeyDown)     //if the z-axis rotation is anything but neutral, and no key is being pressed:
        {
            Vector3 unRighted = transform.eulerAngles;
            unRighted.z = Mathf.LerpAngle(unRighted.z, righted.z, Time.deltaTime * 2f);
            transform.eulerAngles = unRighted;      //lerp back to 'righted'
            
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
            Vector3 leftRoll = transform.eulerAngles;
            leftRoll.z = Mathf.LerpAngle(leftRoll.z, roll, Time.deltaTime * 3f);
            transform.eulerAngles = leftRoll;
            //if (transform.eulerAngles.z < 30f)
            //{
            //    transform.Rotate(transform.position.x, transform.position.y, transform.position.z + roll);        //I want to roll the ship to the left as it banks leftward, but I can't find he magic words.
                    //gotta abandon this bit, it's not working and it's not vital. Code not deleted for posterity and maybe later I'll understand what happened and be able to fix it.
            //}
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(thrust, 0f, 0f, ForceMode.Acceleration);
            Vector3 rightRoll = transform.eulerAngles;
            rightRoll.z = Mathf.LerpAngle(rightRoll.z, -roll, Time.deltaTime * 3f);
            transform.eulerAngles = rightRoll;
            //  holy shit it works, it took four fucking hours but it works
            /*  Griping:
             *  It seems very clumsy and stupid to me that the only way I could manage this was by pulling apart the pieces of the Vector3, changing one bit, and then
             *  putting it back. Why could't I just alter one component directly? I don't understand why I can alter an entire transform.eulerAngles at once,
             *  but not transform.eulerAngles.z in isolation (unless I pull it out to a variable and then shove the whole variable back into the component. I must be missing
             *  something, it's just too ridiculous.
             */

        }
    }
}
