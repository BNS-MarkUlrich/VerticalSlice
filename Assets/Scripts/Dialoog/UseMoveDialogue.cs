using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMoveDialogue : MonoBehaviour
{
    [SerializeField] private DialoogTrigger _dialoogTrigger;

    public void UseMove(string moveName, string pokemonName)
    {
        _dialoogTrigger.StartDialogue(pokemonName + " used " + moveName);
    }

    public void MissMove(string pokeName)
    {
        _dialoogTrigger.StartDialogue(pokeName + "'s attack missed!");
    }

    public void StatChange(string pokeName, string moveName)
    {
        switch (moveName)
        {
            case "GROWL":
                Debug.Log("Growl");
                _dialoogTrigger.StartDialogue(pokeName + "'s ATTACK fell!");
                break;
            case "STRINGSHOT":
                _dialoogTrigger.StartDialogue(pokeName + "'s SPEED fell!");
                Debug.Log("stringshot works");
                break;
            default:
                Debug.Log("moveName invalid");
                break;
        }
    }

}
