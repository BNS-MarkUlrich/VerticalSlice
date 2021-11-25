using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class has 2 functions:
/// 1. To change/add the Dialogue 
/// 2. To Start the Dialogue
/// </summary>
public class DialoogTrigger : MonoBehaviour
{
    [SerializeField] private string[] _sentences;
    [SerializeField] private Text _battleUI;


    public void StartDialogue(string _sentence)
    {
        _battleUI.text = _sentence;
    }

}
