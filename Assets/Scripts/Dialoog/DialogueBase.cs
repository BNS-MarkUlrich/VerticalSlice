using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBase : MonoBehaviour
{
    //bools
    public bool isAutomatic;
    //lists and arrays
    public List<string> sentences;
    [SerializeField] private bool[] _autoArray;
    //int
    public int index;
    public float _timer;
    //scripts
    public DialoogTrigger dialoogTrigger;


    public void AutoOrNot()
    {
        isAutomatic = _autoArray[index];
        if (isAutomatic)
        {
            if (_timer <= 0)
            {
                dialoogTrigger.StartDialogue(sentences[index]);
                index += 1;
                _timer = 3; // Mark Edit
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Debug.Log("werkt");
                dialoogTrigger.StartDialogue(sentences[index]);
                index += 1;
            }
        }
    }

}
