using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapperDialoog : MonoBehaviour
{
    [SerializeField] private DialoogTrigger _dialoogTrigger;
    [SerializeField] private BaseDialoog _baseDialoog;
    [SerializeField] private GameObject _pokemonRival;
    [SerializeField] private GameObject _pokemonPlayer;
    [SerializeField] private int _timer;

    private string _swapRivalDialogue;
    private string _swapPlayerDialogue;

    public bool PorR;

    private void Start()
    {
        PorR = true;
        ChangeDialoog();
    }

    public void StartSwapDia()
    {
        if (PorR == true)
        {
            _dialoogTrigger.StartDialogue(_swapRivalDialogue);
            PorR = false;
            Invoke("StartSwapDia", 5);
        }
        else if (PorR == false)
        {
            _dialoogTrigger.StartDialogue(_swapPlayerDialogue);
            _baseDialoog.ChangeDialoog(_pokemonPlayer.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName);
            Invoke("StartBaseDia",5);
        }
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

    public void ChangeDialoog()
    {
        _swapRivalDialogue = "sent out " + _pokemonRival.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName;
        _swapPlayerDialogue = "Go! " + _pokemonPlayer.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName;
    }

    private void StartBaseDia()
    {
        _baseDialoog.StartDialoog();
    }

   

}
