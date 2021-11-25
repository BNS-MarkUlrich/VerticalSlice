using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialoog : MonoBehaviour
{
    [SerializeField]private int _dialogueTimer;
    [SerializeField] private string _dialogue;
    [SerializeField] private DialoogTrigger _dialoogTrigger;
    [SerializeField] private SwapperDialoog _swapperDialoog;

    private void Start()
    {
        _dialoogTrigger.StartDialogue(_dialogue);        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            _swapperDialoog.StartSwapDia();
            this.gameObject.GetComponent<StartDialoog>().enabled = false;
        }
    }

}
