using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : DialogueBase
{
    private SwapDialogue _swapDia;
    [SerializeField] private GameObject _pokemonRival;
    [SerializeField] private GameObject _pokemonPlayer;
    [SerializeField] private BaseDialoog _baseDialoog;

    private float _activateBaseTimer;

    private void Start()
    {
        _activateBaseTimer = 3; // Mark Edit
        sentences.Add("BUG CATCHER RICK would like to battle!");
        sentences.Add("BUG CATCHER RICK sent out " + _pokemonRival.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName + "!");
        sentences.Add("Go! " + _pokemonPlayer.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName + "!");
        dialoogTrigger.StartDialogue(sentences[index]);
    }

    private void Update()
    {
       
        if(index >= sentences.Count)
        {
            _activateBaseTimer -= Time.deltaTime;
            if(_activateBaseTimer <= 0)
            {
                _baseDialoog.StartDialogue(_pokemonPlayer.GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().pokemonName);
                FindObjectOfType<TurnSystem>().currentState = TurnSystem.TurnSys.RivalTurn;
                this.gameObject.GetComponent<StartDialogue>().enabled = false;
            }
        }
        else
        {
            if (index == 2)
            {
                _audioscript.WeedleCrySFX();
            }
            else if(index == 3)
            {
                _audioscript.BulbasaurCrySFX();
            }
            
            AutoOrNot();
        }
    }


}
