using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip voice1, voice2, voice3, voice4, voice5, voice6, voice7, voice8, knife1, knife2, gamestart, nextround, ready,
                            music1;
    static AudioSource audioSrc;
    static AudioSource audioSrcMusic;

    void Start()
    {
        voice1 = Resources.Load<AudioClip>("Voice1");
        voice2 = Resources.Load<AudioClip>("Voice2");
        voice3 = Resources.Load<AudioClip>("Voice3");
        voice4 = Resources.Load<AudioClip>("Voice4");
        voice5 = Resources.Load<AudioClip>("Voice5");
        voice6 = Resources.Load<AudioClip>("Voice6");
        voice7 = Resources.Load<AudioClip>("Voice7");
        voice8 = Resources.Load<AudioClip>("Voice8");
        knife1 = Resources.Load<AudioClip>("Knife1");
        knife2 = Resources.Load<AudioClip>("Knife2");

        gamestart = Resources.Load<AudioClip>("GameStart");
        nextround = Resources.Load<AudioClip>("NextRound");
        ready = Resources.Load<AudioClip>("Ready");

        music1 = Resources.Load<AudioClip>("Ambience");

        audioSrc = GetComponent<AudioSource>();
        audioSrc.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "Voice1":
                audioSrc.PlayOneShot(voice1, 0.4f);
                break;
            case "Voice2":
                audioSrc.PlayOneShot(voice2, 0.4f);
                break;
            case "Voice3":
                audioSrc.PlayOneShot(voice3, 0.4f);
                break;
            case "Voice4":
                audioSrc.PlayOneShot(voice4, 0.4f);
                break;
            case "Voice5":
                audioSrc.PlayOneShot(voice5, 0.4f);
                break;
            case "Voice6":
                audioSrc.PlayOneShot(voice6, 0.4f);
                break;
            case "Voice7":
                audioSrc.PlayOneShot(voice7, 0.4f);
                break;
            case "Voice8":
                audioSrc.PlayOneShot(voice8, 0.4f);
                break;
            case "Knife1":
                audioSrc.PlayOneShot(knife1, 1f);
                break;
            case "Knife2":
                audioSrc.PlayOneShot(knife2, 1f);
                break;
            case "GameStart":
                audioSrc.PlayOneShot(gamestart);
                break;
            case "NextRound":
                audioSrc.PlayOneShot(nextround);
                break;
            case "Ready":
                audioSrc.PlayOneShot(ready);
                break;


        }
    }

    public static void PlayMusic(string clip)
    {
        switch (clip)
        {
            case "Music1":
                audioSrc.clip = music1;
                audioSrc.volume = 0.5f;
                audioSrc.Play();
                break;

        }
    }



}
