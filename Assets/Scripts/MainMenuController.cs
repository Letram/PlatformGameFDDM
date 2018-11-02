using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {
    public GameObject highscorePanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowHighscore()
    {
        print("Highscore");
        if(PlayerPrefs.HasKey("HighScore"))
            highscorePanel.GetComponent<HighScorePanel>().SendData(PlayerPrefs.GetInt("HighScore"), PlayerPrefs.GetInt("BestScore"), PlayerPrefs.GetInt("BestTime"), PlayerPrefs.GetString("BestPlayer"));
        else
            highscorePanel.GetComponent<HighScorePanel>().SendData(0, 0, 0, "NO ONE YET");
        highscorePanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
