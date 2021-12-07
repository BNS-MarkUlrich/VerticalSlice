using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDialoog : MonoBehaviour
{
    private string _baseDialoog;
    [SerializeField] private DialoogTrigger _dialoogTrigger;

    public void StartDialogue(string pokemonName)
    {
        _baseDialoog = "What will " + pokemonName + " do?";
        _dialoogTrigger.StartDialogue(_baseDialoog);
    }
}
