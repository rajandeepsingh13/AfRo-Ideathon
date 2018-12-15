using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scorekeeper : MonoBehaviour {

    public static Scorekeeper instance;
    public static int TotalScore = 0,CurScore=0;
    public Text[] CurScoreArray, TotScoreArray;
	void Start ()
    {
        instance = this;
        if (PlayerPrefs.HasKey("TotScore"))
        {
            TotalScore = PlayerPrefs.GetInt("TotScore");
        }
        else
            PlayerPrefs.SetInt("TotScore", 0);
	}
	
	
	void Update ()
    {
        foreach (Text x in CurScoreArray)
            x.text = "Score:" + CurScore;
        foreach (Text x in TotScoreArray)
            x.text = "Total score:" + TotalScore;
	}

    public void AddScore(int x)
    {
        CurScore += x;
    }

    public void FinalScore()
    {
        TotalScore += CurScore;
        PlayerPrefs.SetInt("TotScore",TotalScore);
    }

    public void Redeem()
    {
        TotalScore = 0;
        PlayerPrefs.SetInt("TotScore", 0);
    }
}
