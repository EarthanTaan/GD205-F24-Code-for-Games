using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class SpinnerPoints : MonoBehaviour
{
    public int pointstotal;
    void OnCollisionEnter(Collision spinnerHit)
    {
        if (spinnerHit.rigidbody)
        {
            if (spinnerHit.rigidbody.CompareTag("pointsUp"))
            {
                pointstotal += 1;
            } else if (spinnerHit.rigidbody.CompareTag("pointsDn") && pointstotal > 0)
            {
                pointstotal -= 1;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
