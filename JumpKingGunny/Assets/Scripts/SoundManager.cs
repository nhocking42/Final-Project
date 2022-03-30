using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, forceUp;
    static AudioSource audioSrc;
    void Start()
    {
        forceUp = Resources.Load<AudioClip>("forceUp");
        jump = Resources.Load<AudioClip>("Jump");


        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "forceUp":
                audioSrc.PlayOneShot(forceUp);
                break;
        }
    }

    public static void Stop()
    {
        audioSrc.Stop();
    }
}
