using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon : MonoBehaviour
{
    public string pokemonName;
    public string gender;
    public int level;

    public int _attack { get; private set; }
    public int _defence { get; private set; }
    public double trueAttack { get; private set; }
    public int enemyDefence { get; private set; }
    public int _growlCount;
    private double _attackModifier;

    [SerializeField] private PokeTeam pokeTeam;
    public GameObject targetPokemon { get; private set; }
    //[SerializeField] private GameObject[] Attacks;
    [SerializeField] private Genders _currenState = Genders.Male;

    private void Start()
    {
        SetGender();
        pokemonName = gameObject.name.ToUpper();
    }

    private void Update()
    {
        targetPokemon = pokeTeam.GetComponent<PokeTeam>()._pokemons[0];
        enemyDefence = targetPokemon.GetComponent<BasePokemon>()._defence;
    }

    private void getGrowled()
    {
        _growlCount += 1;

        switch (_growlCount)
        {
            case 0:
                _attackModifier = 1;
                return;
            case 1:
                _attackModifier = 0.66;
                return;
            case 2:
                _attackModifier = 0.5;
                return;
            case 3:
                _attackModifier = 0.4;
                return;
            case 4:
                _attackModifier = 0.33;
                return;
            case 5:
                _attackModifier = 0.285;
                return;
            case 6:
                _attackModifier = 0.25;
                return;
        }

        trueAttack = _attack * _attackModifier;
    }

    private void SetGender()
    {
        switch (_currenState)
        {
            case Genders.Genderless:
                gender = "⚥";
                break;
            case Genders.Male:
                gender = "♂";
                break;
            case Genders.Female:
                gender = "♀";
                break;
            default:
                break;
        }
    }

    public enum Genders
    {
        Genderless,
        Male,
        Female
    }
}
