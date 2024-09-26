using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip introMusic; 
    public AudioClip normalGhostMusic; 
    public AudioClip scaredGhostMusic;
    public AudioClip deadGhostMusic; 

    void Start()
    {
        PlayIntroMusic();
    }

    public void PlayIntroMusic()
    {
        audioSource.clip = introMusic;
        audioSource.Play();
        StartCoroutine(WaitForIntroToEnd());
    }

    private IEnumerator WaitForIntroToEnd()
    {
        yield return new WaitForSeconds(introMusic.length);
        PlayNormalGhostMusic();
    }

    public void PlayNormalGhostMusic()
    {
        audioSource.clip = normalGhostMusic;
        audioSource.Play();
    }

    public void PlayScaredGhostMusic()
    {
        audioSource.clip = scaredGhostMusic;
        audioSource.Play();
    }

    public void PlayDeadGhostMusic()
    {
        audioSource.clip = deadGhostMusic;
        audioSource.Play();
    }
}
