using UnityEngine;
using UnityEngine.Assertions.Must;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    float[] laneX = { -6.68f, -5.5f, -4.3f, -3.2f };
    public void SpawnNote(int lane, char noteType)
    {
        Vector3 pos = new Vector3(laneX[lane], 5f, 0f);

        GameObject note = Instantiate(notePrefab, pos, Quaternion.identity);


    // Debug.Log("SpawnNote." + lane);
        Note n = note.GetComponent<Note>();
        if(noteType=='x')
        {
            n.noteType = NoteType.GhostNote;
        }
        else if (noteType == '0')
        {
            n.noteType = NoteType.Standard;
        }
        else 
        {
            n.noteType = NoteType.HeldNote;
            n.noteLength = int.Parse(noteType.ToString());  
        }
        n.lane = lane;
        //Debug.Log("Spawned note in lane: " + lane + " " + n.lane);
    }
}
