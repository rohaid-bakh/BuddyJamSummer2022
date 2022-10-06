using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource source;

    public AudioClip[] audioClips;
    bool playingTextSFX;

    //sound addition
    public bool stopTextSound;
    public bool textFinished;
    public bool clickSoundOn;
    public bool dropSoundOn;

    private void Start()
    {
        //audiotesting
        Debug.Log("playSound");
        source.PlayOneShot(audioClips[1]);
        playingTextSFX = true;

    }
    private void Update()
    {
        if (stopTextSound || textFinished)
        {
            source.Stop();
            stopTextSound = false;
        }

        if (clickSoundOn)
        {
            Debug.Log("clickSound");
            source.PlayOneShot(audioClips[3]);
            clickSoundOn = false;
        }

        if(dropSoundOn)
        {
            source.PlayOneShot(audioClips[4]);
            dropSoundOn = false;
        }
    }

    public void FinishButtonPressed()
    {
        source.PlayOneShot(audioClips[5]);
    }

    public void ButtonPressedSFX()
    {

        if (playingTextSFX)
        {
            source.Stop();
        }
        
        //plays button press sound
        source.PlayOneShot(audioClips[0]);

        //plays text sound
        Debug.Log("playTextSound");
        source.PlayOneShot(audioClips[1]);
        textFinished = false;
    }

}
