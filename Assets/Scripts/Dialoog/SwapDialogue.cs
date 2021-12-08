using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapDialogue : MonoBehaviour
{
    [SerializeField] private DialoogTrigger _dialoogTrigger;
    [SerializeField] private BaseDialoog _baseDialoog;
    [SerializeField] private GameObject _pokemonRival;
    [SerializeField] private GameObject _pokemonPlayer;

    private string _swapRivalDialogue;
    private string _swapPlayerDialogue;

    public void SwapRival()
    {
        _swapRivalDialogue = "BUG CATCHER RICK sent out " + _pokemonRival.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName + "!";
        _dialoogTrigger.StartDialogue(_swapRivalDialogue);
    }

    public void SwapPlayer()
    {
        _swapPlayerDialogue = "Go! " + _pokemonPlayer.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName + "!";
        _dialoogTrigger.StartDialogue(_swapPlayerDialogue);
    }
}
