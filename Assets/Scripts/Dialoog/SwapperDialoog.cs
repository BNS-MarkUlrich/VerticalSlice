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

    public bool PorR;

    private void Start()
    {
        PorR = false;
        _swapRivalDialogue = "sent out " + _pokemonRival.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName;
        _swapPlayerDialogue = "Go! " + _pokemonPlayer.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName;
    }

    public void StartSwapDia()
    {
        _dialoogTrigger.StartDialogue(_swapRivalDialogue);
        Invoke("SwapPokemonDia", 5);
    }

    public void SwapPokemonDia()
    {
        if (PorR == true)
        {
            _dialoogTrigger.StartDialogue(_swapRivalDialogue);
        }
        if (PorR == false)
        {
            _dialoogTrigger.StartDialogue(_swapPlayerDialogue);
        }
    }

}
