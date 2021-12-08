using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthScript : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] public float _curHealth;

    public Slider healthSlider;
    [SerializeField] private Text _healthText;
    private float _barHealth;

    void Start()
    {
        _curHealth = _maxHealth;
        Initialise();
    }

    private void Update()
    {
        if (_healthText != null)
        {
            _healthText.text = _curHealth + "/ " + _maxHealth;
        }
    }

    public void TakeDamage(int damageTaken)
    {
        _curHealth -= damageTaken;
        UpdateHP();
        //play damaged animation
        if (_curHealth <= 0)
        {
            Faint();
        }
    }

    protected virtual void Faint()
    {
        // Doe hier de Faint dingen
        // Play Animation
        gameObject.SetActive(false);
    }

    public void Initialise()
    {
        UpdateHP();
    }

    public void UpdateHP()
    {
        //bar calculations
        _barHealth = _curHealth / _maxHealth * 100;
        healthSlider.value = _barHealth;
    }
}