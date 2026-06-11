using UnityEngine;

public class ScrollForTheCOmic : MonoBehaviour
{
    public float lowerY = 0f;
    public float upperY = 5f;
    public float sensitivity = 0.5f;
    public float moveSpeed = 3f;

    private float targetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;

        targetY += scroll * sensitivity;
        targetY = Mathf.Clamp(targetY, lowerY, upperY);

        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(pos.y, targetY, moveSpeed * Time.deltaTime);

        transform.position = pos;
    }
}
