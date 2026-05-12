using UnityEngine;

public class testLongnote : MonoBehaviour
{
    public float holdTime = 3f;

    private bool holding = false;
    private bool completed = false;
    private float timer = 0f;

    void Update()
    {
        // When key is held
        if (Input.GetKey(KeyCode.Space))
        {
            holding = true;
            timer += Time.deltaTime;

            // Success
            if (timer >= holdTime && !completed)
            {
                completed = true;
                Debug.Log("LONG NOTE HIT!");

                Destroy(gameObject);
            }
        }

        // When key released early
        if (Input.GetKeyUp(KeyCode.Space))
        {
            holding = false;

            if (!completed)
            {
                Debug.Log("MISSED!");
                timer = 0f;
            }
        }
    }
}
