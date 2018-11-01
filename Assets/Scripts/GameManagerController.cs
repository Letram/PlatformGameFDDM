using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManagerController : MonoBehaviour {
    public GameObject player;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI liveCounterText;
    public TextMeshProUGUI scoreText;

    private float startTime;
    private float t;
    private string minutes;
    private string seconds;
    private string miliseconds;
    private bool finished;
    // Use this for initialization
    void Start () {
        player.GetComponent<PlayerController>().SetSpawn(Vector3.zero);
        Time.timeScale = 1;
        startTime = Time.time;
        finished = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!finished)
        {
            t = Time.time - startTime;

            minutes = ((int)t / 60).ToString("00");
            seconds = (t % 60).ToString("00");
            miliseconds = ((int)(t * 100f) % 100).ToString("00");

        }
        DisplayTexts();
	}

    private void DisplayTexts()
    {
        timerText.text = minutes + ":" + seconds + ":" + miliseconds;
        liveCounterText.text = player.GetComponent<PlayerHealth>().GetLives().ToString();
        scoreText.text = player.GetComponent<PlayerController>().GetScore().ToString();
    }

    private void Finished()
    {
        finished = true;
        timerText.color = Color.yellow;
        Time.timeScale = 0;
    }
}
