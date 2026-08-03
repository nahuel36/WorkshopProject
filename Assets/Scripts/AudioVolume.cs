using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioMixer.SetFloat("Volume (of Master)", 0f);//-80 to 20, 0 is default, -80 is mute
        PlayerPrefs.SetFloat("volumen master", 5.5f);
        PlayerPrefs.GetFloat("volumen master", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
