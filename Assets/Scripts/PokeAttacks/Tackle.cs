using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : MonoBehaviour
{
    [SerializeField] private int _dmgValue = 35;
    [SerializeField] private int _accuracy = 85;

    private BasePokemon basePokemon;
    private GameObject target;

    [SerializeField] public int maxPP { get; private set; } = 35;
    [SerializeField] public int ppAmount { get; private set; }
    [SerializeField] private string moveType = "NORMAL";

    private int level;
    private double attack;
    private int enemyDefence;

    public void TackleAttack()
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
        }
        else
        {
            Debug.Log("Attack Missed");
        }
        _ppAmount -= 1;
    }
}