using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioscript : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip stringshot;
    public AudioClip tackle;
    public AudioClip poisonSting;

    public AudioSource audioSource;

    public void PlayTackleSFX()
    {
        Debug.Log("tackle geluiden");
        audioSource.PlayOneShot(stringshot);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayTackleSFX();
        }

    }

}
