using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthScript : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] public float _curHealth;
    [SerializeField] private HealthColor _healthColor;
    [SerializeField] public Audioscript _audioscript;
    [SerializeField] private Animator _hitAni;

    public Slider healthSlider;
    [SerializeField] private Text _healthText;
    private float _barHealth;
    [SerializeField] private float timer = 0.1f;
    private float maxTimer;
    void Start()
    {
        _healthColor.ColourGreen();
        _curHealth = _maxHealth;
        Initialise();
        maxTimer = timer;
    }

    public void Update()
    {
        if (_healthText != null)
        {
            _healthText.text = _curHealth + "/ " + _maxHealth;
        }
        if (this.healthSlider.value <= 20)
        {
            _healthColor.ColourRed();
        }
        if (this.healthSlider.value <= 50 && healthSlider.value >= 21)
        {
            _healthColor.ColourYellow();
        }
        timer -= Time.deltaTime;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
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
            Debug.Log(".");
        }
    }
    private void dealDamage(int damageTaken)
    {
        for (int i = 0; i < 10; i++)
        {
            if (timer <= 0)
            {
                _curHealth -= damageTaken;
                Debug.Log(damageTaken);
                Debug.Log("take damage");
                UpdateHP();
                timer = maxTimer;
            }
        }
        //_audioscript.TakeDamageSFX();
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
        _hitAni.SetBool("isHit", true);
        yield return new WaitForSeconds(1);
        _hitAni.SetBool("isHit", false);
    }
}