using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpticBlast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit beamStrikeReport = new RaycastHit();

        if (Physics.Raycast(laser, out beamStrikeReport))
        {
            Debug.Log("and then I STARTED BLASTIN'");
        }

    }
}
