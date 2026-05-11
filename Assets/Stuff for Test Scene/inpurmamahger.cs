using UnityEngine;

public class inpurmamahger : MonoBehaviour
{
    float hitLineY = -3.72f;//link met scene line

    public int health = 50;
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
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");//bij opstarten laden

        GameObject closestNote = null;

        float closestDistance = 999999f;

        foreach (GameObject noteObj in notes)
        {
            Note note = noteObj.GetComponent<Note>();

            Debug.Log("note: " + note.name + " note.lane: " + note.lane + " ==? " + lane);
            if (note.lane == lane)//per lane bewaren
            {
                float distance = Mathf.Abs(
                    note.transform.position.y - hitLineY // 0 --4 = +4 // -3.99 +4 = 0.01
                );

                Debug.Log("note: " + note.name + " distance: " + distance);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestNote = noteObj;
                }
            }
        }

        if (closestNote != null)
        {
            Debug.Log("closestNote: " + closestNote.name + " distance: " + closestDistance);
            float yPos = closestNote.transform.position.y;

            if (yPos >= -6f && yPos <= -2f)
            {
                Debug.Log("hittttttt");
                health += 5;

                Destroy(closestNote);

                return;
            }
        }

        Debug.Log("</3>");
        health -= 5;
    }
}
