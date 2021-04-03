using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject settings;

    public void ToStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ToChooseLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void ToExit()
    {
        Application.Quit();
    }

    public void ToSettings()
    {
        SceneManager.LoadScene(3);
    }
}
