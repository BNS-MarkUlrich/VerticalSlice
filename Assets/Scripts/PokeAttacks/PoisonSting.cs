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
        _moveType = "normal";
        _ppMax = 35;

        _dmgValue = 15;
        _accuracy = 100;
    }

    public override void Attack()
    {
        level = GetComponent<BasePokemon>().level;
        attack = GetComponent<BasePokemon>().trueAttack;
        enemyDefence = GetComponent<BasePokemon>().enemyDefence;

        target = GetComponent<BasePokemon>().targetPokemon;

        int totalDamage = (int)((((2 * level) / 5) + 2) * _dmgValue * (attack / enemyDefence) / 50 + 2);
        int hitOrMiss = Random.Range(1, 100);

        if (hitOrMiss <= _accuracy)
        {
            target.GetComponent<BaseHealthScript>().TakeDamage(totalDamage);
            Debug.Log(totalDamage);
        }
        else
        {
            Debug.Log("Attack Missed");
        }
        _ppAmount -= 1;
    }
}
