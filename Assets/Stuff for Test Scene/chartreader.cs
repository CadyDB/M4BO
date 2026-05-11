using UnityEngine;
using System.Collections;
public class chartreader : MonoBehaviour
{
    // public GameObject notePrefab;


    string[] chart =
    {
        "0-0-",
        "-0--",
        "--0-",
        "-0--",
        "0---",
        "---0",
        "---0",
        "---0"
    };

    public float beatTime = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        NoteSpawner spawner = GetComponent<NoteSpawner>();
        for (int row = 0; row < chart.Length; row++)
        {
            string line = chart[row];

            for (int lane = 0; lane < 4; lane++)
            {
                if (line[lane] == '0')
                {
                    spawner.SpawnNote(lane);
                }
            }

            yield return new WaitForSeconds(beatTime);
        }
    }
}
