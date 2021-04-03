using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnOff : MonoBehaviour
{
    [SerializeField] int music;
    public AudioSource musicPlay;

    public void Start()
    {
        music = PlayerPrefs.GetInt("music");
        if (music == 1)
        {
            musicPlay.Play();
        }
        else
        {
            musicPlay.Stop();
        }
    }
}
