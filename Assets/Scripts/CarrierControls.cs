using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class CarrierControls : MonoBehaviour
{
    //create a new Rigidbody called rb to manipulate in our script
    Rigidbody rb;
    Quaternion righted;

    //make a new public variable to change our acceleration force (this becomes accessible from the editor side, in the component)
    public float thrust = 50f;
    public float roll = 35f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        righted = transform.rotation;        //grab the Vector3 for when the ship is at neutral rotation

    }

    void FixedUpdate()
    {
        if (Time.fixedTime < 3)
        {
            Material starField = GameObject.Find("Space_BG").GetComponent<MeshRenderer>().material;     // get the material from the starfield plane
            Vector2 starFieldOffset = starField.mainTextureOffset;                                      // pull out the main texture offset and give it a handle
            starFieldOffset.y += Time.deltaTime;                                                    //spike the y axis of the offset for a lightspeed vibe                                                            
            starField.mainTextureOffset = starFieldOffset;                                              //shove the adjust(ing) parameter back into the machine
        }
        else if (Time.fixedTime > 3)
        {
            if (transform.position.z < 100)
            {
                Vector3 currentPos = transform.position;
                currentPos.z = Mathf.Lerp(currentPos.z, 100, Time.deltaTime * 5f);
                transform.position = currentPos;
            }
            GameObject shipSkin = GameObject.Find("Renegade Hope MkIV");
            shipSkin.transform.localPosition = Vector3.Lerp(shipSkin.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime);
        }

        transform.Translate(0, 0, Time.deltaTime * 3f);       // "At rest", the ship moves forward constantly at a slow pace.

        if (transform.eulerAngles.z != 0f && !Input.anyKeyDown)     //if the z-axis rotation is anything but neutral, and no key is being pressed:
        {
            Vector3 recalibrate = transform.position;
            recalibrate.y = Mathf.Lerp(recalibrate.y, 0, Time.deltaTime * 2f);
            transform.position = recalibrate;

            Quaternion unRighted = transform.rotation;      //make a copy of the rotation
            unRighted = Quaternion.Slerp(unRighted, righted, Time.deltaTime * 2f);        //adjust the copy
            transform.rotation = unRighted;     //shove it back in
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
    // Custom functions and classes and stuff goes here: Inside MonoBehavior but outside the other functions (Start and Update).

    /* Write a function here that will handle the intro cutscene, showing the space station wreckage.
     * After panning past the wreck, move the player's ship onto the screen, and turn control over to the input controls.
     * Ideally, then enemies would begin spawning, but I have no clue how to even begin setting THAT up. Set up a custom class maybe?
     * 
     * Or maybe I'm doing it the other way around - all the code I wrote directly into Update() can become the ControlsLive() function, and I can put the cutscene code
     * in Update and have it call ControlsLive() when it's finished...?
    */



} // This line is outside the scope of the MonoBehavior; don't code here or below. This is the bottom of the script.