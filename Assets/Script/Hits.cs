using UnityEngine;
using System.Collections;

public class Hits : MonoBehaviour
{
    
	public bool useInvoke;
	public bool running;
	
	void Start()
	{
	    if (useInvoke)
	        InvokeRepeating("TestInvoke", 0, 3);
	    else
	        StartCoroutine(TestCoroutine());
	}
	
	void TestInvoke()
	{
	    Debug.Log("TestInvoke()");
	}
	
	IEnumerator TestCoroutine()
	{
		running = true;
		
	    while (running)
	    {
	        Debug.Log("TestCoroutine()");
	        yield return new WaitForSeconds(3);
            Debug.Log("TestCoroutine() after wait");
	    }
	}
}
