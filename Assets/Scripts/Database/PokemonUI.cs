using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    //[SerializeField] private Text[] _textElements; // foreach statement?

    [SerializeField] private PokemonInfo _pokemonInfo;
    [SerializeField] private GameObject _pokeTeam;

    public int curHealth;
    //public Slider healthSlider;

    private void Update()
    {
        GetCurHealth();
        switch (_pokemonInfo)  
        {
            case PokemonInfo.PokemonName:
                _text.text = _pokeTeam.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName;
                break;
            case PokemonInfo.PokemonGender:
                _text.text = _pokeTeam.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().gender;
                break;
            case PokemonInfo.PokemonLevel:
                _text.text = _pokeTeam.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().level;
                break;
            case PokemonInfo.PokemonHealth:
                _text.text = curHealth + "/ 20";
                break;
            default:
                break;
        }
    }

    public void GetCurHealth()
    {
        curHealth = _pokeTeam.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().curHealth;
    }

    public enum PokemonInfo
    {
        PokemonName,
        PokemonGender,
        PokemonLevel,
        PokemonHealth
    }
}