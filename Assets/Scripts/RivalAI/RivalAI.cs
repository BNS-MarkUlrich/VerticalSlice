using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalAI : MonoBehaviour
{
    private BaseAttack[] attacks;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attacks = GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().attacks;
    }

    public void RivalAIBehaviour()
    {

    }
}