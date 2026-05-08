using UnityEngine;

public class inpurmamahger : MonoBehaviour
{
    float hitLineY = -3.72f;

    public float perfectRange = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Lane 0");
            CheckLane(0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Lane 1");
            CheckLane(1);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log("Lane 2");
            CheckLane(2);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //Debug.Log("Lane 3");
            CheckLane(3);
        }
    }
    void CheckLane(int lane)
{
    GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");

    GameObject closestNote = null;

    float closestDistance = 999999f;

    foreach (GameObject noteObj in notes)
    {
        Note note = noteObj.GetComponent<Note>();

        if (note.lane == lane)
        {
            float distance = Mathf.Abs(
                note.transform.position.y - hitLineY
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNote = noteObj;
            }
        }
    }

    if (closestNote != null)
    {
        float yPos = closestNote.transform.position.y;

        if (yPos >= -5f && yPos <= -3f)
        {
            Debug.Log("hittttttt");

            Destroy(closestNote);

            return;
        }
    }

    Debug.Log("</3>");
}
}
