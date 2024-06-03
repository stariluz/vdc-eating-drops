using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float initialVolume=100;
    public float currentVolume=50;
    
    [Header("Audio sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Music clips")]
    public AudioClip menuBackground;
    public AudioClip gameBackground;
    // [Header("SFX clips")]
    void Start()
    {
        musicSource.clip=menuBackground;
        musicSource.loop=true;
        musicSource.Play();
    }
}
