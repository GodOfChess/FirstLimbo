using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] int oxygen = 101;
    public Text txto2;
    public GameObject text;
    public GameObject player;
    public PlayerController controller;
    public Animator anim;

    void Start()
    {
        PlayerPrefs.SetInt("oxygen", oxygen);
        txto2.text = "Кислород: " + oxygen.ToString();
        StartCoroutine(ChangeO2());
        controller = player.GetComponent<PlayerController>();
        anim = player.GetComponent<Animator>();
    }

    void Update()
    {
        oxygen = PlayerPrefs.GetInt("oxygen");
        if (oxygen > 100)
        {
            PlayerPrefs.SetInt("oxygen", 100);
        }
        txto2.text = "Кислород: " + oxygen.ToString();  
        if (oxygen < 1) 
        {
            StopCoroutine(ChangeO2());
            controller.speed = 0;
            controller.jumpSpeed = 0;
            controller.waterSpeed = 0;
            anim.SetBool("isDead", true);
            text.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (oxygen <= 20)
        {
            txto2.color = new Color(255, 0, 0);
        }
        else
        {
            txto2.color = new Color(255, 255, 255);
        }
    }

    private IEnumerator ChangeO2()
    {
        oxygen -= 1;
        PlayerPrefs.SetInt("oxygen", oxygen);
        yield return new WaitForSeconds(1f);
        if (oxygen > 0)
        {
            StartCoroutine(ChangeO2());
        }
    }

}

