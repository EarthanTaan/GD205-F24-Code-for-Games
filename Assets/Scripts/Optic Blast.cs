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
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(beamStrikeReport.collider.gameObject);
            }
            else if (Input.GetMouseButtonDown(1) && beamStrikeReport.rigidbody)
            {
                beamStrikeReport.rigidbody.AddExplosionForce(500f, beamStrikeReport.point, 1000f);
            }
        }

    }
}
