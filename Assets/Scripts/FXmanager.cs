using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXmanager : MonoBehaviour
{
    public static AudioClip catchSound;
    static AudioSource audioSrc;
    void Start()
    {
        catchSound = Resources.Load<AudioClip>("catch_ghost");
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
           
        }
    }

}
