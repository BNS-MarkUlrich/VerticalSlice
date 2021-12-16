using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringShot : BaseAttack
{
    [SerializeField] private Audioscript _audioscript;
    [SerializeField] private Animator stringShotAttack;
    [SerializeField] private Animator stringShotWrap;
    [SerializeField] private Animator lowerStat;
    private GameObject target;

    private void Start()
    {
        _moveType = "bug";
        _ppMax = 40;
        _ppAmount = _ppMax; // Mark Added

        _dmgValue = 0;
        _accuracy = 95;

        pokemonName = GetComponentInParent<BasePokemon>().name; // Mark Added
        _audioscript = FindObjectOfType<Audioscript>();
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
            FindObjectOfType<UseMoveDialogue>().UseMove("STRING SHOT", pokemonName.ToUpper());
            StartCoroutine(PlayAnimation());
            // Mark End
            _audioscript.PlayStringShotSFX();
        }
        else
        {
            FindObjectOfType<UseMoveDialogue>().MissMove(pokemonName.ToUpper()); // Mark Added
            Debug.Log(pokemonName.ToUpper() + "Missed" + gameObject.name.ToUpper());
        }
        _ppAmount -= 1;
    }

    public IEnumerator PlayAnimation()
    {
        stringShotAttack.SetBool("useString", true);
        yield return new WaitForSeconds(0.8f);
        stringShotAttack.SetBool("useString", false);
        stringShotWrap.SetBool("useString", true);
        yield return new WaitForSeconds(0.8f);
        stringShotWrap.SetBool("useString", false);
        lowerStat.SetBool("lowerStat", true);
        yield return new WaitForSeconds(0.7f);
        lowerStat.SetBool("lowerStat", false);

    }

}
