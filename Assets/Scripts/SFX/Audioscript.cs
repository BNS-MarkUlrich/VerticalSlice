using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioscript : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip victoryMusic;
    public AudioClip stringShot;
    public AudioClip tackle;
    public AudioClip poisonSting;
    public AudioClip arrowSwitch;
    public AudioClip growl;
    public AudioClip faint;
    public AudioClip buttonPress;
    public AudioClip pokeball;
    public AudioClip bulbCry;
    public AudioClip weedleCry;
    public AudioClip caterpieCry;
    public AudioClip lowerStat;
    public AudioClip damage;
    public AudioClip lowHP;
    public AudioClip gainEXP;

    public AudioSource audioSource;

    /*
     * every function that has a // is already called on. 
     * Function without // still need to be called on in another script
     */

    public void PlayTackleSFX() //
    {
        audioSource.PlayOneShot(tackle, 5);
    }

    public void PlayStringShotSFX()//
    {
        audioSource.PlayOneShot(stringShot, 5);
        Invoke("LowerStatSFX", 1);
    }

    public void PlayPoisonStingSFX()//
    {
        audioSource.PlayOneShot(poisonSting, 5);
    }

    public void PlayGrowlSFX()//
    {
        audioSource.PlayOneShot(growl, 5);
        Invoke("LowerStatSFX", 1);
    }

    public void PlayVictorySFX()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(victoryMusic);    
    }

    public void ArrowSwitchSFX()//
    {
        audioSource.PlayOneShot(arrowSwitch, 0.6f);
    }

    public void FaintSFX()//
    {
        audioSource.PlayOneShot(faint);
    }

    public void ButtonPressSFX() //
    {
        audioSource.PlayOneShot(buttonPress, 0.6f);    
    }

    public void PokeballSFX()
    {
        audioSource.PlayOneShot(pokeball);
    }

    public void CaterpieCrySFX()//
    {
        audioSource.PlayOneShot(caterpieCry);
    }

    public void WeedleCrySFX()//
    {
        audioSource.PlayOneShot(weedleCry, 0.05f);
    }

    public void BulbasaurCrySFX()//
    {
        audioSource.PlayOneShot(bulbCry, 12);
    }

    public void TakeDamageSFX()
    {
        audioSource.PlayOneShot(damage);
    }

    public void LowHPSFX()
    {
        audioSource.PlayOneShot(lowHP);
    }

    public void GainEXPSFX()
    {
        audioSource.PlayOneShot(gainEXP);
    }

    private void LowerStatSFX()//
    {
        audioSource.PlayOneShot(lowerStat, 5);
    }
}
