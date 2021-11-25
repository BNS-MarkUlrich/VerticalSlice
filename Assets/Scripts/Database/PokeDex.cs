using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeDex : MonoBehaviour
{
    [SerializeField] private List<BasePokemon> _pokemons;

    public PokeDex()
    {
        _pokemons = new List<BasePokemon>();
    }

    public void AddItem(BasePokemon pokemon)
    {
        _pokemons.Add(pokemon);
    }

    public BasePokemon[] GetAllItems()
    {
        return _pokemons.ToArray();
    }

    /*static void Main()
    {
        Database database = new Database();
        Faction human = new Faction("Human");
        Faction borg = new Faction("Borg");
        database.AddItem(borg);
        database.AddItem(human);
        foreach (Faction f in database.GetAllItems())
        {
            Console.WriteLine("Faction: {0}", f._name);
        }
        database.GetAllItems();
    }*/
}
