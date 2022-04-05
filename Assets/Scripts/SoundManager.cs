using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource fxSource;

    public AudioClip menuMusic;
    public AudioClip effect;

    public Slider musicslider, fxslider;

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void playFX ()
    {
        fxSource.PlayOneShot(effect);
    }
    
    public void playMusic (AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }

    public void OnMusicVolumeUpdate()
    {
        musicSource.volume = musicslider.value;
    } 
    
    public void OnFXVolumeUpdate()
    {
        fxSource.volume = fxslider.value;
    }
}
