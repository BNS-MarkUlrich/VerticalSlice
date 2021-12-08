using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioscript : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip stringShot;
    public AudioClip tackle;
    public AudioClip poisonSting;
    public AudioClip arrowSwitch;
    public AudioClip faint;
    public AudioClip buttonPress;
    public AudioClip pokeball;
    public AudioClip bulbCry;
    public AudioClip weedleCry;
    public AudioClip caterpieCry;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource.PlayOneShot(backgroundMusic);
    }

    public void PlayTackleSFX()
    {
        audioSource.PlayOneShot(tackle);
    }

    public void PlayStringShotSFX()
    {
        audioSource.PlayOneShot(stringShot);
    }

    public void PlayPoisonStingSFX()
    {
        audioSource.PlayOneShot(poisonSting);
    }

    public void ArrowSwitchSFX()
    {
        audioSource.PlayOneShot(arrowSwitch);
    }

    public void FaintSFX()
    {
        audioSource.PlayOneShot(faint);
    }

    public void ButtonPressSFX() 
    {
        audioSource.PlayOneShot(buttonPress);    
    }

    public void PokeballSFX()
    {
        audioSource.PlayOneShot(pokeball);
    }

    public void CaterpieCrySFX()
    {
        audioSource.PlayOneShot(caterpieCry);
    }

    public void WeedleCrySFX()
    {
        audioSource.PlayOneShot(weedleCry);
    }

    public void BulbasaurCrySFX()
    {
        audioSource.PlayOneShot(bulbCry);
    }
}
