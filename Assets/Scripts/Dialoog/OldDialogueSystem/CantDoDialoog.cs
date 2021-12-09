using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantDoDialoog : MonoBehaviour
{

    private string _cantRunDia;
    private string _cantCatchDia;
    private DialoogTrigger _dialoogTrigger;

    public void CantRun()
    {
        _cantRunDia = "No! There's no running from a TRAINER battle!";
        _dialoogTrigger.StartDialogue(_cantRunDia);
        
    }

    public void CantCatchPokemonFirstLine()
    {
        _cantCatchDia = "The TRAINER blocked the ball";
        _dialoogTrigger.StartDialogue(_cantCatchDia);
        Invoke("CantCatchPokemonSecondLine", 5);
    }

    private void CantCatchPokemonSecondLine()
    {
        _cantCatchDia = "Don't be a thief!";
        _dialoogTrigger.StartDialogue(_cantCatchDia);
    }
}
