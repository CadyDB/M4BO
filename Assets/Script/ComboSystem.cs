using System;
using System.Collections.Generic;
using UnityEngine;
public class ComboSystem : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();   //lijst met geraakte tags
    private int scoreMultiplier = 1;

    public static Action<int, int> OnScoreChange { get; internal set; }

    private void Start()
    {
        
        BumperHit.onBumperHit += CheckForCombo;             //luisteren naar action event onBumperHit als game start
    }
    private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;             //stop met luisteren naar action event onBumperHit als scene herstart of game stopt
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
        ScoreManager.Instance.AddScore(bumperValue * scoreMultiplier);

        //print score en multiplier in de console
        Debug.Log($"Score: {ScoreManager.Instance.score} || Multiplier: {scoreMultiplier}X");
    }
}