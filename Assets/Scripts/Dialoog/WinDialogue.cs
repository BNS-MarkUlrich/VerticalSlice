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
    }
    void Update()
    {
        if (index >= sentences.Count)
        {
            Invoke("EndGame", 5);
        }
    }

    private void EndGame()
    {
        //laat de game eindigen 
    }
}
