using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growl : BaseAttack
{
    private GameObject target;

    private void Start()
    {
        _moveType = "normal";
        _ppMax = 40;

        _dmgValue = 0;
        _accuracy = 100;
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
            target.GetComponent<BasePokemon>().GetGrowled();
        }
        else
        {
            Debug.Log("Attack Missed");
        }
        _ppAmount -= 1;
    }
}
