using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeTeam : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pokemons;

    public PokeTeam()
    {
        _pokemons = new List<GameObject>();
    }

    public GameObject[] GetAllItems()
    {
        return _pokemons.ToArray();
    }
}