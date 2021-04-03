using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLight : MonoBehaviour
{
    [SerializeField] float light;
    public GameObject lg;
    Light l;
    void Start()
    {
        light = PlayerPrefs.GetFloat("light");
        l = lg.GetComponent<Light>();
        l.intensity = light;
    }

    
    void Update()
    {
        
    }
}
