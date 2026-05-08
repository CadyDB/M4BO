using UnityEngine;

public class inpurmamahger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Lane 0");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Lane 1");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Lane 2");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Lane 3");
        }
    }
}
