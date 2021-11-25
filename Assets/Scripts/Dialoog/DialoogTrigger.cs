using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class has 1 function: To change the Dialogue 
/// </summary>
public class DialoogTrigger : MonoBehaviour
{
    [SerializeField] private Text _battleUI;

    public void StartDialogue(string _sentence)
    {
        _battleUI.text = _sentence;
    }

}
