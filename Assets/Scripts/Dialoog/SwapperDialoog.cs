using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapperDialoog : MonoBehaviour
{
    [SerializeField] private DialoogTrigger _dialoogTrigger;
    [SerializeField] private BaseDialoog _baseDialoog;
    [SerializeField] private PokeTeam _pokemonRival;
    [SerializeField] private PokeTeam _pokemonPlayer;

    private string _swapRivalDialogue;
    private string _swapPlayerDialogue;

    public bool PorR;

    private TurnSystem turnSys; // Test: add back later?

    private void Start()
    {
        turnSys = FindObjectOfType<TurnSystem>(); // Test: add back later?
        turnSys.currentState = TurnSystem.TurnSys.DialogueState; // Test: add back later?
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
            _baseDialoog.ChangeDialoog(_pokemonPlayer.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName); // Test: add back later?
            turnSys.PlayerTurn(); // Test: add back later?
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
        _swapRivalDialogue = _pokemonRival.trainerName + " sent out " + _pokemonRival._pokemons[0].GetComponent<BasePokemon>().pokemonName + "!"; // Test: add back later?
        _swapPlayerDialogue = "Go! " + _pokemonPlayer._pokemons[0].GetComponent<BasePokemon>().pokemonName + "!"; // Test: add back later?
    }

    private void StartBaseDia()
    {
        _baseDialoog.StartDialogue();
    }

   

}
