using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScorePanel : MonoBehaviour {
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI highScore;

    internal void SendData(int highScore, int bestScore, int bestTime, string playerName)
    {
        this.playerName.text ="Name: " + playerName;
        this.bestScore.text = "Score: " + bestScore.ToString();
        this.highScore.text = "Highscore: " + highScore.ToString();

        string minutes = ((int)bestTime / 60).ToString("00");
        string seconds = (bestTime % 60).ToString("00");
        string miliseconds = ((int)(bestTime* 100f) % 100).ToString("00");
        this.bestTime.text = "Time: " + minutes + ":" + seconds + ":" + miliseconds;
    }

    public void back()
    {
        this.gameObject.SetActive(false);
    }
}
