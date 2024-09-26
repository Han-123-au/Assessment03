using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAudioController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip scaredSound; 
    public AudioClip deathSound; 

    public void PlayScaredSound()
    {
        audioSource.PlayOneShot(scaredSound);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
