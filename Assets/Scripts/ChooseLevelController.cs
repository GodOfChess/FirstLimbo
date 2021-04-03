using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelController : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToFirstLvl()
    {
        SceneManager.LoadScene(5);
    }
    public void ToSecondLvl()
    {
        SceneManager.LoadScene(6);
    }
    public void ToThirdLvl()
    {
        SceneManager.LoadScene(7);
    }
}
