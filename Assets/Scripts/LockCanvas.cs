using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockCanvas : MonoBehaviour
{
    public GameObject canv;
    [SerializeField] bool isOpen = false;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOpen)
        {
			Cursor.visible = true;
            canv.SetActive(true);
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOpen)
        {
            canv.SetActive(false);
            isOpen = false;
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToContinue()
    {
        canv.SetActive(false);
        isOpen = false;
    }
}
