using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeTeam : MonoBehaviour
{
    [SerializeField] public List<GameObject> _pokemons;

    public float curHealth;
    public Slider healthSlider;

    private int _targetStartHealth;
    private float _barHealth;

    [SerializeField] private Text _nameText;
    [SerializeField] private Text _genderText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _healthText;

    public GameObject[] GetAllItems()
    {
        return _pokemons.ToArray();
    }

    private void Update()
    {
        _nameText.text = _pokemons[0].GetComponent<BasePokemon>().pokemonName;
        _genderText.text = _pokemons[0].GetComponent<BasePokemon>().gender;
        _levelText.text = _pokemons[0].GetComponent<BasePokemon>().level;
        if (_healthText != null)
        {
            _healthText.text = curHealth + "/ " + _targetStartHealth;
        }
    }

    public void Initialise(int startHP)
    {
        _targetStartHealth = startHP;
        UpdateHP(startHP);
    }

    public void UpdateHP(int health)
    {
        curHealth = health;

        //bar calculations
        _barHealth = curHealth / _targetStartHealth * 100;
        healthSlider.value = _barHealth;
    }
}