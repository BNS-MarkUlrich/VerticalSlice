using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystemBackup : MonoBehaviour
{
    [SerializeField] private float _turnCounter = 1;

    public TurnSys currentState;

    public float timer;
    private float startTimer;

    private void Start()
    {
        startTimer = timer;
    }

    private void Update()
    {
        if (_turnCounter % 2 == 1) // Player turn on uneven numbers
        {
            currentState = TurnSys.PlayerTurn;
        }
        else if (_turnCounter % 2 == 0 ) // Rival turn on even numbers
        {
            currentState = TurnSys.RivalTurn;
        }

        switch (currentState)
        {
            case TurnSys.PlayerTurn:
                // Do something
                //Invoke("TestTimer", 3);
                // !Do something
                break;
            case TurnSys.RivalTurn:
                // Call RivalAI script
                //Invoke("TestTimer", 3);
                // !Call RivalAI script
                break;
            default:
                break;
        }
    }

    public void TestTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            _turnCounter += 1;
            timer = startTimer;
        }
    }

    public void SwapTurn()
    {
        Debug.Log(_turnCounter);
        _turnCounter += 1;
    }

    public enum TurnSys
    {
        PlayerTurn,
        RivalTurn
    }
}
