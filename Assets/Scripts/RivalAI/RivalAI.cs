using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalAI : MonoBehaviour
{
    [SerializeField] private BaseAttack[] attacks;

    // Update is called once per frame
    void Update()
    {
        attacks = GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().attacks;
    }

    public void RivalAIBehaviour()
    {
        int attackChoice = (int)Random.Range(0, attacks.Length);

        attacks[attackChoice].Attack();
        Debug.Log(attacks[attackChoice]);
    }
}