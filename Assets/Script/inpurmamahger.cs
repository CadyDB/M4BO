using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using System;

public class inpurmamahger : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();   //lijst met geraakte tags
    private int scoreMultiplier = 1;
    public static Action<int, int> OnScoreChange { get; internal set; }
    public static event Action<string, int> onBumperHit;
    float hitLineY = -3.72f;//link met scene line
    public int health = Mathf.Clamp(100, 0, 100);
    public static int score = 0;
    public float perfectRange = 0.3f;
    public static inpurmamahger Instance;
    
    public  TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        inpurmamahger.onBumperHit += CheckForCombo;
    }
    private void OnDisable()
    {
        inpurmamahger.onBumperHit -= CheckForCombo;
        //stop met luisteren naar action event onBumperHit als scene herstart of game stopt             
    }

    // Update is called once per frame
    void Update()
    {
    //for all holdnotes -> check of knop nog ingedrukt isj
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Lane 0");
            CheckLane(0);
            //als note returned ->  check holdnote? -> YES  -> bewaar
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            //Debug.Log("Lane 0");
            //CheckLane(0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Lane 1");
            CheckLane(1);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            //Debug.Log("Lane 1");
            //CheckLane(1);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log("Lane 2");
            CheckLane(2);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            //Debug.Log("Lane 2");
            //CheckLane(2);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //Debug.Log("Lane 3");
            CheckLane(3);
        }
        
        if (Input.GetKeyUp(KeyCode.K))
        {
            //Debug.Log("Lane 3");
            //CheckLane(3);
        }
        scoreText.text = inpurmamahger.score.ToString();
    }
    Note CheckLane(int lane)
    {
        
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");//bij opstarten laden

        GameObject closestNote = null;

        float closestDistance = 999999f;

        foreach (GameObject noteObj in notes)
        {
            Note note = noteObj.GetComponent<Note>();

        //als deze note een hold is (boolean) return note
            //Debug.Log("note: " + note.name + " note.lane: " + note.lane + " ==? " + lane);
            if (note.lane == lane)//per lane bewaren
            {
                float distance = Mathf.Abs(
                    note.transform.position.y - hitLineY // 0 --4 = +4 // -3.99 +4 = 0.01
                );

                //Debug.Log("note: " + note.name + " distance: " + distance);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestNote = noteObj;
                }
            }
        }

        if (closestNote != null)
        {
            //Debug.Log("closestNote: " + closestNote.name + " distance: " + closestDistance);
            float yPos = closestNote.transform.position.y;

            if (yPos >= -4.5f && yPos <= -3.5f)
            {
                Debug.Log("HIT PERFECT");
                health += 5;
                score += 30;

                Destroy(closestNote);

                return closestNote.GetComponent<Note>();
            }
            if (yPos >= -3.5f && yPos <= -2f)
            {
                Debug.Log("HIT EARLY");
                health += 0;
                score += 15;

                Destroy(closestNote);

                return closestNote.GetComponent<Note>();
            }
        }

        Debug.Log("HIT MISS");
        health -= 5;

        if (health < 0)
        {
            Die();
        }
        return null;
        
            
    }
    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
    public void h0ealth()
    {
        health = Mathf.Clamp(health, 0, 100);
    }
    private void CheckForCombo(string tag, int bumperValue)
    {

        Debug.Log("check combo");
        bumperTags.Add(tag);                              
        if (bumperTags.Count > 1)                      
        {
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;
            }
            else
            {
                scoreMultiplier = 1;
                bumperTags.Clear();
            }
        }                                                   
        inpurmamahger.Instance.AddScore(bumperValue * scoreMultiplier);

        //print score en multiplier in de console
        Debug.Log($"Score: {score} || Multiplier: {scoreMultiplier}X");
    }
    public void AddScore(int amount)
    {
        score = score + amount;
        // debug voor testen
       Debug.Log("Score: " + score);
    }
}
