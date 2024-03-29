using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tackle : BaseAttack
{
    [SerializeField] private Audioscript _audioscript;

    private GameObject target;

    [SerializeField] private GameObject thisPokemon;

    public Animator poisonStingAnimator;

    private int level;
    private int attack;
    private int enemyDefence;

    public float aniTimer = 0.405f;

    private void Start()
    {
        _moveType = "normal";
        _ppMax = 35;
        _ppAmount = _ppMax; // Mark Added

        _dmgValue = 35;
        _accuracy = 95;

        pokemonName = GetComponentInParent<BasePokemon>().name; // Mark Added      
    }

    private void Update()
    {
        level = GetComponentInParent<BasePokemon>().level;
        attack = GetComponentInParent<BasePokemon>().trueAttack;
        enemyDefence = GetComponentInParent<BasePokemon>().enemyDefence;

        target = GetComponentInParent<BasePokemon>().targetPokemon;

        poisonStingAnimator.SetBool("FireTackleAttack", fireAttack);
    }

    public override void Attack()
    {
        int totalDamage = ((((2 * level) / 5) + 2) * _dmgValue * (attack / enemyDefence) / 50 + 2);
        int hitOrMiss = Random.Range(1, 100);

        if (hitOrMiss <= _accuracy)
        {
            //play attack animation
            fireAttack = true;
            StartCoroutine(Timer());
            target.GetComponent<BaseHealthScript>().TakeDamage(totalDamage);
            FindObjectOfType<UseMoveDialogue>().UseMove("TACKLE", pokemonName.ToUpper());
            // Mark End
            _audioscript.PlayTackleSFX();
            Debug.Log(totalDamage);
        }
        else
        {
            FindObjectOfType<UseMoveDialogue>().MissMove(pokemonName.ToUpper()); // Mark Added
            Debug.Log(pokemonName.ToUpper() + "Missed" + gameObject.name.ToUpper());
        }
        _ppAmount -= 1;
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.05f);
        thisPokemon.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(aniTimer);
        thisPokemon.GetComponent<Image>().enabled = true;
    }
}