using UnityEngine;

public class notespwner : MonoBehaviour
{
    public GameObject notePrefab;
    float[] laneX = { -3f, -1f, 1f, 3f };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnNote(int lane)
    {
        Vector3 pos = new Vector3(laneX[lane], 5f, 0f);

        GameObject note = Instantiate(notePrefab, pos, Quaternion.identity);

        note.GetComponent<Note>().lane = lane;
    }
}
