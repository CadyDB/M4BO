using UnityEngine;
using System.Collections;
public class chartreader : MonoBehaviour
{
    public GameObject notePrefab;

    float[] laneX = { -3f, -1f, 1f, 3f };

    string[] chart =
    {
        "0-0-",
        "-0-0",
        "--0-",
        "00--",
        "0-0-",
        "00-0",
        "--0-",
        "0-00"
    };

    public float beatTime = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        for (int row = 0; row < chart.Length; row++)
        {
            string line = chart[row];

            for (int lane = 0; lane < 4; lane++)
            {
                if (line[lane] == '0')
                {
                    SpawnNote(lane);
                }
            }

            yield return new WaitForSeconds(beatTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnNote(int lane)
    {
        Vector3 pos = new Vector3(laneX[lane], 5f, 0f);

        Instantiate(notePrefab, pos, Quaternion.identity);
    }
}
