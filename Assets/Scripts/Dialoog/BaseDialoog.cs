using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDialoog : MonoBehaviour
{
    private string _baseDialoog;
    [SerializeField] private DialoogTrigger _dialoogTrigger;

    public void ChangeDialoog(string pokemonName) 
    {
        _baseDialoog = "What will " + pokemonName + "do";
    }

    public void StartDialogue()
    {
        _dialoogTrigger.StartDialogue(_baseDialoog);
    }
}
