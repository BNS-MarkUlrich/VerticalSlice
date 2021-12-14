using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeTeam : MonoBehaviour
{
    [SerializeField] public List<GameObject> _pokemons;

    

    public PokeTeam oppositeTeam;

    public GameObject[] GetAllItems()
    {
        return _pokemons.ToArray();
    }

    private void Start()
    {
        for (int i = 1; i < _pokemons.Count; i++)
        {
            _pokemons[i].SetActive(false);
        }
    } 
}