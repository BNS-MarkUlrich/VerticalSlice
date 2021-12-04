using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDialogue : DialogueBase
{
    void Start()
    {
        sentences.Add("PLAYER defeated BUG CATCHER RICK");
        sentences.Add("No! " + "CATERPIE can't hack it!");
        sentences.Add("Player got ₽72 for winning!");
        dialoogTrigger.StartDialogue(sentences[index]);
        _timer = 5;
        index = 1;
    }
    void Update()
    {
        if (index >= sentences.Count)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Debug.Log("Endgame");
            }
        }
        else
        {
            AutoOrNot();
        }
    }

}
