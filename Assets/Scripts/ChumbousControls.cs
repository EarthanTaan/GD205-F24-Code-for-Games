using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Vector3 cameraOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraOffset = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        cameraOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up) * cameraOffset;

        Camera.main.transform.position = gameObject.transform.position + cameraOffset;

        Camera.main.transform.LookAt(transform.position);

        Camera.main.transform.position = cameraOffset;

        GetComponent<Animator>().SetFloat("Forward", 0f);
        GetComponent<Animator>().SetFloat("Left", 0f);
        GetComponent<Animator>().SetFloat("Right", 0f);

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetFloat("Forward", 1f);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Animator>().SetFloat("Forward", GetComponent<Animator>().GetFloat("Forward") * 2);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetFloat("Left", 1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetFloat("Right", 1f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetFloat("Forward", -1f);
        }
    }
}
