using UnityEngine;
using System.Collections;
using Stariluz.GameLoop;

public class AudioManager : MonoBehaviour, IGameElement
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Music Clips")]
    public AudioClip startGameBackground;
    public AudioClip gameplayBackground;

    [Header("SFX Clips")]
    public AudioClip winSound;
    public AudioClip gameOverSound;
    public AudioClip scoreSound;

    void Start(){
        musicSource.clip=startGameBackground;
        musicSource.Play();
        musicSource.loop=true;
    }
    public void StartGamePlay()
    {
        musicSource.clip=gameplayBackground;
        musicSource.Play();
        musicSource.loop=true;
    }
    public void OnGameOver()
    {
        sfxSource.clip = gameOverSound;
        sfxSource.Play();
    }
	public void OnGameWin()
	{
        sfxSource.clip = winSound;
        sfxSource.Play();
    }
    public void OnScore()
    {
        sfxSource.clip = scoreSound;
        sfxSource.Play();
    }
    float savedTime=0.0f;
    float savedPauseTime=0.0f;
    public void Pause()
    {
        musicSource.Pause();
        savedPauseTime=musicSource.time;

        musicSource.clip=startGameBackground;
        musicSource.time=savedTime;
        musicSource.Play();
    }

    public void Resume()
    {
        musicSource.Pause();
        savedTime=musicSource.time;

        musicSource.clip=gameplayBackground;
        musicSource.time=savedPauseTime;
        musicSource.Play();
    }

    public void StopGamePlay()
    {
        throw new System.NotImplementedException();
    }
}

