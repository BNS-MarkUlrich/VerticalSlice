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
    private float _timer;
    //scripts
    [SerializeField] private DialoogTrigger _dialoogTrigger;

    private void Start()
    {
        _dialoogTrigger.StartDialogue(sentences[index]);
        index += 1;
    }

    private void Update()
    {
        if (isAutomatic)
        {
            if (_timer <= 0)
            {
                _dialoogTrigger.StartDialogue(sentences[index]);
                isAutomatic = _autoArray[index];
                index += 1;
                _timer = 5;
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
                _dialoogTrigger.StartDialogue(sentences[index]);
                index += 1;
            }
        }
    }

}
