using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXmanager : MonoBehaviour
{
    static AudioSource audioSrc;
    public static AudioClip catchSound;
    public static AudioClip walkSound;

    void Start()
    {
        catchSound = Resources.Load<AudioClip>("catch_ghost");
        walkSound = Resources.Load<AudioClip>("walk");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "catch_ghost":
                audioSrc.PlayOneShot(catchSound);
                break;
            case "walk":
                audioSrc.PlayOneShot(walkSound);
                break;
           
        }
    }

}
