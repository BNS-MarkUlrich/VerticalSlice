using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeTeam : MonoBehaviour
{
    [SerializeField] public List<GameObject> _pokemons;

    private void Start()
    {
        _pokemons = new List<GameObject>();
    }
    public GameObject[] GetAllItems()
    {
        return _pokemons.ToArray();
    }
}