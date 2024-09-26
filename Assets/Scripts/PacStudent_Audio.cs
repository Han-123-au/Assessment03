using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentAudioController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip moveClip; 
    public AudioClip eatPelletClip; 
    public AudioClip collideWallClip; 
    public AudioClip deathClip; 

    public void PlayMoveSound()
    {
        audioSource.PlayOneShot(moveClip);
    }

    public void PlayEatPelletSound()
    {
        audioSource.PlayOneShot(eatPelletClip);
    }

    public void PlayCollideWallSound()
    {
        audioSource.PlayOneShot(collideWallClip);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }
}
