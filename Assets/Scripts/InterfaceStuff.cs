using UnityEditor.UIElements;
using UnityEngine;

public class InterfaceStuff : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
