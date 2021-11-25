using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon : MonoBehaviour
{
    public string pokemonName;
    private string gender;
    public string level;
    public int levelNum;
    //[SerializeField] private GameObject[] Attacks;
    [SerializeField] private States _currenState = States.Genderless;

    private void Start()
    {
        level = "Lv" + levelNum.ToString();
        SetGender();
        pokemonName = gameObject.name + gender;
    }

    private void SetGender()
    {
        switch (_currenState)
        {
            case States.Genderless:
                gender = "⚥";
                break;
            case States.Male:
                gender = "♂";
                break;
            case States.Female:
                gender = "♀";
                break;
            default:
                break;
        }
    }

    public enum States
    {
        Genderless,
        Male,
        Female
    }
}
