using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon : MonoBehaviour
{
    public string pokemonName;
    public string gender;
    public int level;

    public int _attack;
    public int _defence;
    public int trueAttack { get; private set; }
    public int enemyDefence { get; private set; }
    public int _growlCount;
    private double _attackModifier;

    public GameObject targetPokemon { get; private set; }

    private PokeTeam rivalTeam;
    public BaseAttack[] attacks;
    [SerializeField] private Genders _currenState = Genders.Male;

    private void Awake()
    {
        SetGender();
        pokemonName = gameObject.name.ToUpper();
    }

    private void Start()
    {
        attacks = GetComponentsInChildren<BaseAttack>();
    }

    private void Update()
    {
        rivalTeam = GetComponentInParent<PokeTeam>().oppositeTeam;
        targetPokemon = rivalTeam._pokemons[0];
        enemyDefence = targetPokemon.GetComponent<BasePokemon>()._defence;
    }

    public void GetGrowled()
    {
        _growlCount += 1;

        switch (_growlCount)
        {
            case 0:
                _attackModifier = 1;
                break;
            case 1:
                _attackModifier = 0.66;
                break;
            case 2:
                _attackModifier = 0.5;
                break;
            case 3:
                _attackModifier = 0.4;
                break;
            case 4:
                _attackModifier = 0.33;
                break;
            case 5:
                _attackModifier = 0.285;
                break;
            case 6:
                _attackModifier = 0.25;
                break;
            case 7:
                _growlCount = 6;
                break;
        }

        trueAttack = (int)_attack * (int)_attackModifier;
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
