using System;
using System.Collections;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.Reflection;

public class inpurmamahger : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();   //lijst met geraakte tags
    public int comboMultiplier = 1;
    public static Action<int, int> OnScoreChange { get; internal set; }
    //public static event Action<string, int> onBumperHit;
    float hitLineY = -3.72f;//link met scene line
    public int health = Mathf.Clamp(100, 0, 100);
    public static int score = 0;
    public float perfectRange = 0.3f;
    public static inpurmamahger Instance;
    public Image healthImage;
    public GameObject Perfect;
    public GameObject Good;
    public GameObject Bad;
    public GameObject Miss;
    public static int perfect = 0;
    public static int miss = 0;
    public static int bad = 0;
    
    public  TextMeshProUGUI scoreText;
    public  TextMeshProUGUI scoreTextDone;
    public TextMeshProUGUI prefectText;
    public TextMeshProUGUI missText;
    public TextMeshProUGUI badText;
    public TextMeshProUGUI Multiplyer;
    
    private Note[] lanenotes = new Note[4];
   
    void Start()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        scoreTextDone = GameObject.FindWithTag("ScoreDone").GetComponent<TextMeshProUGUI>();
        prefectText = GameObject.FindWithTag("Perfect").GetComponent<TextMeshProUGUI>();
        missText = GameObject.FindWithTag("Miss").GetComponent<TextMeshProUGUI>();
        badText = GameObject.FindWithTag("Bad").GetComponent<TextMeshProUGUI>();
        Multiplyer = GameObject.FindWithTag("Multi").GetComponent<TextMeshProUGUI>();
    }
    private void OnDisable()
    {

        //stop met luisteren naar action event onBumperHit als scene herstart of game stopt             
    }
    void Awake()
    {
        score = 0;
        perfect = 0;
        miss = 0;
        bad = 0;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    
    void Update()
    {
        comboMultiplier = Mathf.Min(comboMultiplier * 1, 16);
        scoreText.text = inpurmamahger.score.ToString();
        scoreTextDone.text = inpurmamahger.score.ToString();
        prefectText.text = inpurmamahger.perfect.ToString();
        missText.text = inpurmamahger.miss.ToString();
        badText.text = inpurmamahger.bad.ToString();
        //Multiplyer.text = inpurmamahger.comboMultiplier.ToString();
        healthImage.fillAmount = health / 100f;
        health = Mathf.Clamp(health, 0, 100);
        for (int i = 0; i < lanenotes.Length; i++) 
        { 
            checkHeldNote(i);

        }
            //for all holdnotes -> check of knop nog ingedrukt isj
            if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Lane 0");
            lanenotes[0] = CheckLane(0); 
            //als note returned ->  check holdnote? -> YES  -> bewaar
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Lane 1");
            lanenotes[1] = CheckLane(1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log("Lane 2");
            lanenotes[2] = CheckLane(2);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //Debug.Log("Lane 3");
            lanenotes[3] = CheckLane(3);
        }
    }
    void checkHeldNote(int lane)
    {
        Note note = lanenotes[lane];
        if (note != null)
        {
            if (Input.GetKey(KeyCode.D) && lane == 0 ||
                Input.GetKey(KeyCode.F) && lane == 1 ||
                Input.GetKey(KeyCode.J) && lane == 2 ||
                Input.GetKey(KeyCode.K) && lane == 3)
            {
                Debug.Log("Holding note in lane " + lane);
            }
            else
            {
                lanenotes[lane] = null;
            }
        }
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
                comboMultiplier *= 2;
                health += 5;
                perfect += 1;
                Perfecthit();
                score += 30 * comboMultiplier;
                Destroy(closestNote);
                return closestNote.GetComponent<Note>();
            }
            if (yPos >= -3.5f && yPos <= -2f)
            {
                Debug.Log("HIT EARLY");
                Badhit();
                bad += 1;
                score += 15 * comboMultiplier;
                Destroy(closestNote);
                return closestNote.GetComponent<Note>();
            }
        }
        Debug.Log("HIT MISS");
        Misshit();
        comboMultiplier = 1;
        miss += 1;
        if (health <= 0)
        {
            Die();
        }
        return null;
    }
    void OnCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            Debug.Log("Collision with Note");
            health -= 10;
        }
    }
    public void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
    public void h0ealth()
    {
        health = Mathf.Clamp(health, 0, 100);
    }
    
    public void AddScore(int amount)
    {
        score = score + amount;
        Debug.Log("Score: " + score);
    }
    public void Perfecthit()
    {
        Instantiate(Perfect, new Vector2( 0, 0), Quaternion.identity);
    }
    public void Misshit()
    {
        Instantiate(Miss, new Vector2( 0, 0), Quaternion.identity);
    }
    public void Badhit()
    {
        Instantiate(Bad, new Vector2( 0, 0), Quaternion.identity);
    }
}