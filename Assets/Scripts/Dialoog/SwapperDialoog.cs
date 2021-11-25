using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapperDialoog : MonoBehaviour
{
    [SerializeField] private DialoogTrigger _dialoogTrigger;
    [SerializeField] private int _timer;

    private string _swapRivalDialogue;
    private string _swapPlayerDialogue;
    private int _startSwap;


    private void Start()
    {
        //_swapRivalDialogue = rivalName + "sent out" + pokemon;
        //_swapPlayerDialogue = "Go!" + pokemon;
    }

    private void Update()
    {
        if (_startSwap == 1)
        {
            SwapPokemonDia(false);
            _startSwap = 2;
        }
    }

    public void SwapPokemonDia(bool PorR)
    {
        if (PorR)
        {
            _dialoogTrigger.StartDialogue(_swapRivalDialogue);
        }
        else if (PorR == false)
        {
            _dialoogTrigger.StartDialogue(_swapPlayerDialogue);
        }

        if(_startSwap == 0)
        {
            _startSwap = 1;
        }
    }

}
