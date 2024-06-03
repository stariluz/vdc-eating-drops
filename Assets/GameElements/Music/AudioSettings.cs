using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public float initialVolume = 100;
    public float currentVolume = 50;

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider slider;
    void Start()
    {

    }
}
