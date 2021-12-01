using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon : MonoBehaviour
{
    public string pokemonName;
    public string gender;
    public string level;
    public int levelNum;
    //[SerializeField] private GameObject[] Attacks;
    [SerializeField] private Genders _currenState = Genders.Male;

    private void Awake()
    {
        SetGender();
        pokemonName = gameObject.name.ToUpper();
        level = "Lv" + levelNum.ToString();
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
