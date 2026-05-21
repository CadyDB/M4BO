using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    float[] laneX = { -6.68f, -5.5f, -4.3f, -3.2f };
    public void SpawnNote(int lane)
    {
        Vector3 pos = new Vector3(laneX[lane], 5f, 0f);

        GameObject note = Instantiate(notePrefab, pos, Quaternion.identity);


    // Debug.Log("SpawnNote." + lane);
        Note n = note.GetComponent<Note>();
        n.lane = lane;
        //Debug.Log("Spawned note in lane: " + lane + " " + n.lane);
    }
}
