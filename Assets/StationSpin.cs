using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UIElements;

public class StationSpin : MonoBehaviour
{
    /*  This is to animate the destroyed space station parts with some spin individually. I don't know if it will really work, but it....should, right?
     *  idk, Who knows anything? Unity is so confusing.
     */

    //Let's get some variables going I guess? Let's see, I don't need a handle for the station itself because it's what this script is attached to.

    // module4: Lower Solar Panels
    Transform LSP;

    [SerializeField]
    float LSPspin = 150;
    [SerializeField]
    float stationSpin = 1.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LSP = transform.Find("module4");
    }

    // Update is called once per frame
    void Update()
    {
        // Let's spin the whole thing, I think it'll look more spacey.
        transform.Rotate(new Vector3(0,0,stationSpin * Time.deltaTime));
            // I was going to try to make the pieces drift apart but it turned out more complicated than I expected and I don't have time to chase this car.

        // module7: The Wheel
        transform.Find("module7").transform.Rotate(new Vector3(0,0,10*Time.deltaTime));     //it worked!

        /*  Note to self:
         *  To reference an axis, the Vector3 format is just a value of 1 on that axis with zeroes in the other axes.
         *  So transform.up is Vector3(0,1,0) or 1 in the y axis.
         *  transform.right is Vector3(1,0,0)
         *  I don't know what the "shortcut" is for the z axis and I don't want to know. Vector3(0,0,1) makes much more sense and is universally applicable regardless of the specific parameters in which it is used.
         *  I hate these shortcuts like, conceptually, which is why I have written myself this note as a reminder. (I don't want to have to be translating what I think "up" means after accounting for whatever other transformations and parent-child relationships have taken place.)
        */

        // module4: Lower Solar Panels, or LSP
        //LSP.RotateAround(LSP.position, LSP.right, LSPspin * Time.deltaTime);     //It's hard to express how and why I think this is an incredibly stupid solution and it makes me more angry at Unity than when I was stumped. But whatever it works.
        LSP.Rotate(new Vector3(LSPspin * Time.deltaTime, 0,0), Space.Self);        //figured out a "better" solution (I realized it is almost identical). Keeping the other one commeneted out just for posterity.

        // module4.001: Upper Solar Panels, or USP
        transform.Find("module4.001").transform.Rotate(new Vector3(-LSPspin * 0.25f * Time.deltaTime, 0, 10 * Time.deltaTime), Space.Self);       // One line, you (I) love to see it.

    }
}

// That'll do. Calling this finished.
