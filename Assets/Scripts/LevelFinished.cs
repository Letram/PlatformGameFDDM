using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    public TextMeshProUGUI timeInput;
    public TextMeshProUGUI scoreInput;
    public TMP_InputField playerNameInput;

    private float finalTime;
    private int finalScore;
    private string playerName;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    internal void Populate(float finalTime, int finalScore)
    {
        this.finalTime = finalTime;
        this.finalScore = finalScore;

        string minutes = ((int)finalTime / 60).ToString("00");
        string seconds = (finalTime % 60).ToString("00");
        string miliseconds = ((int)(finalTime * 100f) % 100).ToString("00");
        timeInput.text = minutes + ":" + seconds + ":" + miliseconds;
        scoreInput.text = finalScore.ToString();
    }

    public void SubmitData()
    {
        if(playerNameInput.text != "")
        {
            int currentScore = (int)finalTime + finalScore;
            //first play of the game or beating the highscore
            if (!PlayerPrefs.HasKey("HighScore") || PlayerPrefs.GetInt("HighScore") < currentScore)
            {
                print("Eres el fucker -> " + currentScore);
                PlayerPrefs.SetInt("BestTime", (int)finalTime);
                PlayerPrefs.SetInt("BestScore", finalScore);
                PlayerPrefs.SetString("BestPlayer", playerNameInput.text);
                PlayerPrefs.SetInt("HighScore", currentScore);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene("Menu");
        }
    }
}
