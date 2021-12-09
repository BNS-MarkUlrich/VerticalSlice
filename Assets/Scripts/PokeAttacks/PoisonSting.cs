using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSting : BaseAttack
{
    [SerializeField] private Audioscript _audioscript;

    private GameObject target;

    //private Animation poisonStingAnim;
    public Animator poisonStingAnimator;

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
        //poisonStingAnim = GetComponent<Animation>();
    }

    private void Update()
    {
        level = GetComponentInParent<BasePokemon>().level;
        attack = GetComponentInParent<BasePokemon>().trueAttack;
        enemyDefence = GetComponentInParent<BasePokemon>().enemyDefence;

        target = GetComponentInParent<BasePokemon>().targetPokemon;

        poisonStingAnimator.SetBool("FirePoisonSting", fireAttack);
    }

    public override void Attack()
    {
        int totalDamage = (int)((((2 * level) / 5) + 2) * _dmgValue * (attack / enemyDefence) / 50 + 2);
        int hitOrMiss = Random.Range(1, 100);

        if (hitOrMiss <= _accuracy)
        {
            //play attack animation
            fireAttack = true;
            //poisonStingAnim.Play("sting poison sting");
            // Mark Begin
            FindObjectOfType<UseMoveDialogue>().UseMove("POISON STING", pokemonName.ToUpper());
            // Mark End
            target.GetComponent<BaseHealthScript>().TakeDamage(totalDamage);
            _audioscript.PlayPoisonStingSFX();
            Debug.Log(totalDamage);
        }
        else
        {
            Debug.Log("Attack Missed");
        }
        _ppAmount -= 1;
    }
}
