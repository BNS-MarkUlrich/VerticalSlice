using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growl : BaseAttack
{
    private GameObject target;
    [SerializeField] Audioscript _audioscript;

    private void Start()
    {
        _moveType = "normal";
        _ppMax = 40;
        _ppAmount = _ppMax; // Mark Added

        _dmgValue = 0;
        _accuracy = 100;

        pokemonName = GetComponentInParent<BasePokemon>().name; // Mark Added
    }
    private void Update()
    {
        target = GetComponentInParent<BasePokemon>().targetPokemon;
    }

    public override void Attack()
    {
        int hitOrMiss = Random.Range(1, 100);

        if (hitOrMiss <= _accuracy)
        {
            //play attack animation
            FindObjectOfType<UseMoveDialogue>().UseMove("GROWL", pokemonName.ToUpper());
            target.GetComponent<BasePokemon>().GetGrowled();
            _audioscript.PlayGrowlSFX();
        }
        else
        {
            FindObjectOfType<UseMoveDialogue>().MissMove(pokemonName.ToUpper()); // Mark Added
            Debug.Log(pokemonName.ToUpper() + "Missed" + gameObject.name.ToUpper());
        }
        _ppAmount -= 1;
    }
}
