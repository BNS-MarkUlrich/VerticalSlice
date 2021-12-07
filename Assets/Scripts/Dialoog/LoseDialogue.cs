using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDialogue : DialogueBase
{
    // Start is called before the first frame update
    void Start()
    {
        sentences.Add("BULBASAUR fainted");
        sentences.Add("Player is out of usable pokemon");
        sentences.Add("Player lost against BUG CATCHER RICK!");
        sentences.Add("Player paid ₽40 as the prize money...");
        sentences.Add("... ... ... ...");
        sentences.Add("Player whited out!");
    }

    // Update is called once per frame
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
