using UnityEngine;
using UnityEngine.UIElements;

//  Based on a tutorial video I found - This script takes a looped image and scrolls it across an object to give the impression of motion.

public class bg_scroll : MonoBehaviour
{
    //Serialized these so I could tweak them while running to get the right speed of star drift.
    [SerializeField]
    float xMod = 0.0015f;
    [SerializeField]
    float yMod = 0.03f;
    
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();     //tracking down the material that the starfield object is using
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;             //I guess we can't adjust the offset directly? We have to copy it to a variable, adust it and then send it back? I don't understand why, but that's what the tutorial I found said.
        offset.y += Time.deltaTime * yMod;                  //I want the player to always be drifting forward a bit. This will scroll the material texture even while still.
        offset.x = transform.position.x * xMod;             //slide the stars left and right in accordance with the ship's lateral motion.
        mat.mainTextureOffset = offset;                     //send the adjustments back to the component in the editor.
    }
}
