using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    [SerializeField] int music;
    [SerializeField] float light;
    public AudioSource musicPlay;
    private Image imgMusic;
    public List<Sprite> images = new List<Sprite>();
    public GameObject musicobj;
    public Slider brightSlider;
    public void Start()
    {
        music = PlayerPrefs.GetInt("music");
        light = PlayerPrefs.GetFloat("light");
        brightSlider.value = light;
        imgMusic = musicobj.GetComponent<Image>();
        if (music == 1)
        {
            musicPlay.Play();
        }
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (music == 1)
        {
            imgMusic.sprite = images[0];
        }
        else
        {
            imgMusic.sprite = images[1];
        }
    }

    public void ControlMusic()
    {
        if (music == 1)
        {
            music = 0;
            musicPlay.Stop();
        }
        else
        {
            music = 1;
            musicPlay.Play();
        }
        PlayerPrefs.SetInt("music", music);
    }

    public void ChangeBright()
    {
        PlayerPrefs.SetFloat("light", brightSlider.value);
    }
}
