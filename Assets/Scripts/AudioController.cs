using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;

    public AudioClip moveClip;
    public AudioClip eatPelletClip;
    public AudioClip collideWallClip;
    public AudioClip ghostChaseClip;
    public AudioClip deathClip;

    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        backgroundMusicSource.clip = ghostChaseClip;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayMoveSound()
    {
        PlaySoundEffect(moveClip);
    }

    public void PlayEatPelletSound()
    {
        PlaySoundEffect(eatPelletClip);
    }

    public void PlayCollideWallSound()
    {
        PlaySoundEffect(collideWallClip);
    }

    public void PlayDeathSound()
    {
        PlaySoundEffect(deathClip);
    }

    void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);
    }
}
