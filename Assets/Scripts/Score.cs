using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TMP_Text text;
    public static Score instance; 
   
    void Awake()
    {
        text.text = "0";
        instance = this;
    }
    private int score;

    public void ScoreUp()
    {
        score++;
        text.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
}
