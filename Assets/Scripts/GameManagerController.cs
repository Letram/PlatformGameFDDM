using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManagerController : MonoBehaviour {
    public GameObject player;
    public RocketLauncherController rocketLauncher;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI liveCounterText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public GameObject ammoPanel;
    public GameObject finishPanel;
    public float startTime = 600;
    private float t;
    private string minutes;
    private string seconds;
    private string miliseconds;
    private bool finished;
    private int finalScore;
    private float finalTime;
    private AudioSource audio;
    // Use this for initialization
    void Start () {
        player.GetComponent<PlayerController>().SetSpawn(Vector3.zero);
        Time.timeScale = 1;
        //startTime = Time.time;
        finished = false;
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<PlayerHealth>().GetLives() == -1)
            Finished();
        if (!finished)
        {
            t = startTime - Time.time;

            minutes = ((int)t / 60).ToString("00");
            seconds = (t % 60).ToString("00");
            miliseconds = ((int)(t * 100f) % 100).ToString("00");
            DisplayTexts();

        }
	}

    private void DisplayTexts()
    {
        timerText.text = minutes + ":" + seconds + ":" + miliseconds;
        liveCounterText.text = player.GetComponent<PlayerHealth>().GetLives().ToString();
        scoreText.text = player.GetComponent<PlayerController>().GetScore().ToString();
        if (player.GetComponent<PlayerController>().isWeaponPicked())
        {
            ammoPanel.SetActive(true);
        }
        ammoText.text = rocketLauncher.getAmmo().ToString();
        //print(player.GetComponentInChildren<RocketLauncherController>().getAmmo().ToString());
    }

    private void Finished()
    {
        finished = true;
        timerText.color = Color.yellow;
        finalScore = player.GetComponent<PlayerController>().GetScore();
        finalTime = t;
        finishPanel.gameObject.GetComponent<LevelFinished>().Populate(finalTime, finalScore);
        finishPanel.SetActive(true);
        Time.timeScale = 0;
        audio.Play();
    }
}
