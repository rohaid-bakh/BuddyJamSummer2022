using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [NonReorderable]
    public Sound[] sounds;

    //for muting/unmuting audio
    public bool muted;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    private void Start()
    {
        Play("BackgroundMusic");
        //Play("TextSFX");
    }
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void MuteAudio()
    {
        if (!muted)
        {
            //mute
            Sound s = Array.Find(sounds, sound => sound.name == name);
            for (int i = 0; i < sounds.Length; i++)
            {
                s = sounds[i];
                s.source.mute = true;
                muted = true;
            }
        }

        else
        {
            //unmute
            Sound s = Array.Find(sounds, sound => sound.name == name);
            for (int i = 0; i < sounds.Length; i++)
            {
                s = sounds[i];
                s.source.mute = false;
                muted = false;
            }
        }

    }


 
}
