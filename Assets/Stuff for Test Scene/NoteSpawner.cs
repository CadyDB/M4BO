using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    float[] laneX = { -3f, -1f, 1f, 3f };
    public void SpawnNote(int lane)
    {
        Vector3 pos = new Vector3(laneX[lane], 5f, 0f);

        GameObject note = Instantiate(notePrefab, pos, Quaternion.identity);


        Note n = note.GetComponent<Note>();
        n.lane = lane;
        Debug.Log("Spawned note in lane: " + lane + " " + n.lane);
    }
}
