using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMoveDialogue : MonoBehaviour
{
    private DialoogTrigger _dialoogTrigger;

    public void UseMove(string moveName, string pokemonName)
    {
        _dialoogTrigger.StartDialogue(pokemonName + " used " + moveName);
    }

    public void MissMove(string pokeName)
    {
        _dialoogTrigger.StartDialogue(pokeName + "'s attack missed!");
    }

}
