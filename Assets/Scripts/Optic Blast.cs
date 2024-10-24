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
        Ray beam = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit beamStrikeReport = new RaycastHit();
        
        if (Physics.Raycast(beam, out beamStrikeReport))
        {
            if (beamStrikeReport.rigidbody)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    beamStrikeReport.rigidbody.AddExplosionForce(-3000f, beamStrikeReport.point, 10f);
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    beamStrikeReport.rigidbody.AddExplosionForce(3000f, beamStrikeReport.point, 10f);
                }
            }
        }

    }
}
