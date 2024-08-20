using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Toggle toggleTutorial;
    public void TurnOnGameOver()
    {
        gameOverScreen.SetActive(true);
        if (PlayerPrefs.GetInt("Tutorial") == 0)
            toggleTutorial.isOn = false;
        else
            toggleTutorial.isOn = true;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TutorialOnOff(Toggle toggle)
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("Tutorial", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Tutorial", 0);
        }
    }
}
