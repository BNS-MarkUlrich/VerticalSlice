using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringShot : BaseAttack
{
    private GameObject target;

    private void Start()
    {
        _moveType = "bug";
        _ppMax = 40;
        _ppAmount = _ppMax; // Mark Added

        _dmgValue = 0;
        _accuracy = 95;

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
            // Mark Begin
            FindObjectOfType<UseMoveDialogue>().UseMove("STRING SHOT", pokemonName.ToUpper());
            // Mark End
        }
        else
        {
            Debug.Log("Attack Missed");
        }
        _ppAmount -= 1;
    }
}
