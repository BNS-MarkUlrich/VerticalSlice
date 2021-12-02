using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : BaseAttack
{
    private GameObject target;

    private int level;
    private int attack;
    private int enemyDefence;

    private void Start()
    {
        _moveType = "normal";
        _ppMax = 35;

        _dmgValue = 35;
        _accuracy = 85;
    }

    private void Update()
    {
        level = GetComponentInParent<BasePokemon>().level;
        attack = GetComponentInParent<BasePokemon>().trueAttack;
        enemyDefence = GetComponentInParent<BasePokemon>().enemyDefence;

        target = GetComponentInParent<BasePokemon>().targetPokemon;
    }

        int totalDamage = ((((2 * level) / 5) + 2) * _dmgValue * (attack / enemyDefence) / 50 + 2);
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