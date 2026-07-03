using UnityEngine;
using System.Collections;

public class endscreenforsongs : MonoBehaviour
{
    public bool useInvoke;
	public bool running;
    public GameObject container;
    public int time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
	        //Debug.Log("TestCoroutine()");
	        yield return new WaitForSeconds(time);
            //Debug.Log("TestCoroutine() after wait");
            EndGame();
	    }
	}
    public void EndGame()
    {
        container.SetActive(true);
        //Time.timeScale = 0;
        AudioListener.pause = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
