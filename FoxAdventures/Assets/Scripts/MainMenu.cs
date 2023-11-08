using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public void Play()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void Quit()
    {
        Debug.Log("Quit...");
        // Quit the game
        Application.Quit();
    }
}
