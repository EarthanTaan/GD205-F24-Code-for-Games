using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

//  Based on a tutorial video I found - This script takes a looped image and scrolls it across an object to give the impression of motion.

public class bg_scroll : MonoBehaviour
{
    //Serialized these so I could view/tweak them while running to get the right speed of star drift.
    [SerializeField]
    float xMod = 0.0015f;
    [SerializeField]
    float yMod = 0.03f;
    [SerializeField]
    float velMod = 0f;

    Renderer spaceRenderer;

    GameObject Carrier;     //declaring these handles to use below. I'm getting errors in the editor though, so let me try moving the assignments into Start().
    Rigidbody CarrierRB;    //(cont'd) That worked.

    private void Start()
    {
        Carrier = GameObject.Find("Carrier");
        CarrierRB = GameObject.Find("Carrier").GetComponent<Rigidbody>();
        spaceRenderer = GetComponent<Renderer>();
        
    }

    void Update()
    {
        
        if (CarrierRB.linearVelocity.z > 0)
        {
            velMod = CarrierRB.linearVelocity.z * 0.01f;    //increase the rate of illusory speed by a fraction of the actual speed
            if (velMod > 0.2f)
            {
                velMod = 0.2f;      //cap the speed
            }
        }
        else
        {
            velMod = 0f;            //prevent the starfield going backwards (even if the player does)
        }

        MeshRenderer mr = GetComponent<MeshRenderer>();     //tracking down the material that the starfield object is using
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;             //I guess we can't adjust the offset directly? We have to copy it to a variable, adust it and then send it back? I don't understand why, but that's what the tutorial I found said.
        offset.y += Time.deltaTime * (yMod+velMod);                  //I want the player to always be drifting forward a bit. This will scroll the material texture even while still.
        offset.x = transform.position.x * xMod;             //slide the stars left and right in accordance with the ship's lateral motion.
        mat.mainTextureOffset = offset;                     //send the adjustments back to the component in the editor.
    }
}
