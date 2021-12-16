using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthScript : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] public float _curHealth;
    [SerializeField] public Audioscript _audioscript;
    [SerializeField] private Animator _hitAni;
    public Image pokemonImage;
    public float timerAni;

    public Slider healthSlider;
    [SerializeField] private Text _healthText;
    private float _barHealth;

    void Start()
    {
        _audioscript = FindObjectOfType<Audioscript>();
        _curHealth = _maxHealth;
        Initialise();
    }

    public void TakeDamage(float damageTaken)
    {
        _curHealth -= damageTaken;
        //UpdateHP();
        //play damaged animation
        StartCoroutine(Timer());
        if (_curHealth <= 0)
        {
            Faint();
        }
        
    }

    protected virtual void Faint()
    {
        // Doe hier de Faint dingen
        // Play Animation
        _audioscript.FaintSFX();
        gameObject.SetActive(false);
    }

    public void Initialise()
    {
        UpdateHP();
    }

    public void UpdateHP()
    {
        if (_healthText != null)
        {
            _healthText.text = _curHealth + "/ " + _maxHealth;
        }

        //bar calculations
        _barHealth = _curHealth / _maxHealth * 100;
        healthSlider.value = _barHealth;
    }
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        _hitAni.SetBool("isHit", true);
        pokemonImage.enabled = false;
        _audioscript.TakeDamageSFX();
        yield return new WaitForSeconds(0.1f);
        _hitAni.SetBool("isHit", false);
        yield return new WaitForSeconds(timerAni);
        pokemonImage.enabled = true;
    }
}