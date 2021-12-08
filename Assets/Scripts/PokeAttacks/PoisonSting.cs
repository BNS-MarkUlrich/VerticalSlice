using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSting : BaseAttack
{
    private GameObject target;

    private int level;
    private int attack;
    private int enemyDefence;

    private void Start()
    {
        _moveType = "poison";
        _ppMax = 35;
        _ppAmount = _ppMax; // Mark Added

        _dmgValue = 15;
        _accuracy = 100;

        pokemonName = GetComponentInParent<BasePokemon>().name; // Mark Added
    }

    private void Update()
    {
        level = GetComponentInParent<BasePokemon>().level;
        attack = GetComponentInParent<BasePokemon>().trueAttack;
        enemyDefence = GetComponentInParent<BasePokemon>().enemyDefence;

        target = GetComponentInParent<BasePokemon>().targetPokemon;
    }

    public override void Attack()
    {
        int totalDamage = (int)((((2 * level) / 5) + 2) * _dmgValue * (attack / enemyDefence) / 50 + 2);
        int hitOrMiss = Random.Range(1, 100);

        if (hitOrMiss <= _accuracy)
        {
            //play attack animation
            FindObjectOfType<UseMoveDialogue>().UseMove("POISON STING", pokemonName.ToUpper());
            target.GetComponent<BaseHealthScript>().TakeDamage(totalDamage);
            //Debug.Log(totalDamage);
        }
        else
        {
            FindObjectOfType<UseMoveDialogue>().MissMove(pokemonName.ToUpper()); // Mark Added
            Debug.Log(pokemonName.ToUpper() + " Missed " + gameObject.name.ToUpper());
        }
        _ppAmount -= 1;
    }
}
