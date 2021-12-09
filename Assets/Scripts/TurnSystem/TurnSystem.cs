using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public TurnSys currentState = TurnSys.DialogueState;

    [SerializeField] private PokeTeam rival;
    [SerializeField] private PokeTeam player;

    public List<BaseAttack> attackTurns;

    [SerializeField] public GameObject dialogueSystem;

    private RivalAI rivalAI;

    public bool controls; //{ get; private set; }

    [SerializeField] private float timer = 2;
    private float maxTimer;

    private void Start()
    {
        rivalAI = rival.GetComponent<RivalAI>();
        maxTimer = timer;
    }

    private void Update()
    {
        switch (currentState) 
        {
            case TurnSys.PlayerTurn:
                // Do something
                controls = true;
                FindObjectOfType<OptionScript>().optionsMenu.SetActive(true);
                // !Do something
                break;
            case TurnSys.RivalTurn:
                // Call RivalAI script
                controls = false;
                rivalAI.Invoke("RivalAIBehaviour", 0);

                dialogueSystem.GetComponent<BaseDialoog>().StartDialogue(player._pokemons[0].name);
                PlayerTurn();
                // !Call RivalAI script
                break;
            case TurnSys.DialogueState:
                // Do something
                controls = false;
                FindObjectOfType<OptionScript>().optionsMenu.SetActive(false);
                // !Do something
                break;
            case TurnSys.RivalAttackState:
                // Do something
                controls = false;
                FindObjectOfType<OptionScript>().optionsMenu.SetActive(false);
                attackTurns[0].Attack();
                AttackTurn();
                // !Do something
                break;
            case TurnSys.PlayerAttackState:
                // Do something
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    attackTurns[0].fireAttack = false;
                    player._pokemons[0].GetComponent<BaseHealthScript>().UpdateHP();
                    attackTurns[1].Attack();
                    attackTurns.Clear();
                    timer = maxTimer;
                    currentState = TurnSys.PostAttackState;
                }
                // !Do something
                break;
            case TurnSys.PostAttackState:
                // Do something
                if (rival._pokemons[0].GetComponent<BaseHealthScript>()._curHealth <= 0)
                {
                    dialogueSystem.GetComponent<FaintedDialogue>().PokemonFainted(rival._pokemons[0].name.ToUpper());
                    currentState = TurnSys.FeintState;
                }
                else
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        rival._pokemons[0].GetComponent<BaseHealthScript>().UpdateHP();
                        timer = maxTimer;
                        RivalTurn();
                    }
                }
                // !Do something
                break;
            case TurnSys.FeintState:
                // Do something
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Destroy(rival._pokemons[0]);
                    rival._pokemons.RemoveAt(0);
                    dialogueSystem.GetComponent<SwapDialogue>().SwapRival();
                    rival._pokemons[0].SetActive(true);
                    currentState = TurnSys.PostAttackState;
                }
                // !Do something
                break;
            default:
                break;
        }
    }

    public void PlayerTurn()
    {
        currentState = TurnSys.PlayerTurn;
    }

    public void RivalTurn()
    {
        currentState = TurnSys.RivalTurn;
    }

    public void AttackTurn()
    {
        currentState = TurnSys.PlayerAttackState;
    }

    public enum TurnSys
    {
        PlayerTurn,
        RivalTurn,
        DialogueState,
        RivalAttackState,
        PlayerAttackState,
        PostAttackState,
        FeintState
    }
}