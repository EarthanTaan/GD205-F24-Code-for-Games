using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Animator>().SetFloat("Forward", 0f);
        GetComponent<Animator>().SetFloat("Left", 0f);
        GetComponent<Animator>().SetFloat("Right", 0f);

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetFloat("Forward", 1f);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Animator>().SetFloat("Forward", 2f);
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Animator>().SetFloat("Forward", -2f);
            }
        }
    }
}
