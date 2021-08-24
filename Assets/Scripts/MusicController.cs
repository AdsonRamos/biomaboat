using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    public AudioClip gameMusic;
    public AudioClip menuMusic;

    private void Awake() {
        if (instance == null){
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    public void PlayGameMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = gameMusic;
        audio.Play();
    }

    public void PlayMenuMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = menuMusic;
        audio.Play();
    }
}
