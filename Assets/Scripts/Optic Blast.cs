using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            if (beamStrikeReport.rigidbody.gameObject.tag == "orb")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    beamStrikeReport.rigidbody.AddExplosionForce(-500f, beamStrikeReport.point, -1000f);
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    beamStrikeReport.rigidbody.AddExplosionForce(500f, beamStrikeReport.point, 1000f);
                }
            }
        }

    }
}
