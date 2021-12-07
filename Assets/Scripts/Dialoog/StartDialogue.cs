using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : DialogueBase
{
    void Awake()
    {
        sentences.Add("BUG CATCHER RICK would like to battle");
    }

    private void Update()
    {
        if(index >= sentences.Count)
        {
            this.gameObject.GetComponent<StartDialogue>().enabled = false;
        }
    }
}
