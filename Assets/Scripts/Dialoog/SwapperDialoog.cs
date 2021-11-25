using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapperDialoog : MonoBehaviour
{
    [SerializeField] private DialoogTrigger _dialoogTrigger;
    [SerializeField] private GameObject _pokemonRival;
    [SerializeField] private GameObject _pokemonPlayer;
    [SerializeField] private int _timer;

    private string _swapRivalDialogue;
    private string _swapPlayerDialogue;
    private int _startSwap;

    private void Start()
    {
        //_pokemonRival.GetComponent<PokeTeam>()._pokemons[0];
        //_pokemonPlayer = GetComponent<PokeTeam>()._pokemons[0];
        _swapRivalDialogue = "sent out " + _pokemonRival.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName;
        _swapPlayerDialogue = "Go! " + _pokemonPlayer.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName;
    }

    private void Update()
    {
        if (_startSwap == 1)
        {
            SwapPokemonDia(false);
            _startSwap = 2;
        }
        Debug.Log(_startSwap);
    }

    public void SwapPokemonDia(bool PorR)
    {
        Debug.Log(PorR);
        if (PorR == true)
        {
            _dialoogTrigger.StartDialogue(_swapRivalDialogue);
        }
        if (PorR == false)
        {
            _dialoogTrigger.StartDialogue(_swapPlayerDialogue);
        }

        if(_startSwap == 0)
        {
            _startSwap = 1;
        }
    }

}
