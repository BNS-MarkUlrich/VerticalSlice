using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeTeam : MonoBehaviour
{
    [SerializeField] public List<GameObject> _pokemons;

    [SerializeField] private Text _nameText;
    [SerializeField] private Text _genderText;
    [SerializeField] private Text _levelText;

    public PokeTeam oppositeTeam;

    public GameObject[] GetAllItems()
    {
        return _pokemons.ToArray();
    }

    private void Start()
    {
        for (int i = 1; i < _pokemons.Count; i++)
        {
            _pokemons[i].SetActive(false);
        }
    }

    private void Update()
    {
        _nameText.text = _pokemons[0].GetComponent<BasePokemon>().pokemonName;
        _genderText.text = _pokemons[0].GetComponent<BasePokemon>().gender;
        _levelText.text = "Lv" + _pokemons[0].GetComponent<BasePokemon>().level;
    }    
}