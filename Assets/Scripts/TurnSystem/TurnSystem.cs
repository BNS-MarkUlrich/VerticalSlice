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
                controls = true;
                FindObjectOfType<OptionScript>().optionsMenu.SetActive(true);

                break;
            case TurnSys.RivalTurn:
                controls = false;
                rivalAI.Invoke("RivalAIBehaviour", 0);

                dialogueSystem.GetComponent<BaseDialoog>().StartDialogue(player._pokemons[0].name);
                PlayerTurn();

                break;
            case TurnSys.DialogueState:
                controls = false;
                FindObjectOfType<OptionScript>().optionsMenu.SetActive(false);

                break;
            case TurnSys.RivalAttackState:
                controls = false;
                FindObjectOfType<OptionScript>().optionsMenu.SetActive(false);
                attackTurns[0].Attack();
                AttackTurn();

                break;
            case TurnSys.PlayerAttackState:
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

                break;
            case TurnSys.PostAttackState:
                if (rival._pokemons[0].GetComponent<BaseHealthScript>()._curHealth <= 0)
                {
                    dialogueSystem.GetComponent<FaintedDialogue>().PokemonFainted(rival._pokemons[0].name.ToUpper());
                    currentState = TurnSys.FeintState;
                }
                else if (player._pokemons[0].GetComponent<BaseHealthScript>()._curHealth <= 0)
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

                break;
            case TurnSys.FeintState:
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    if (rival._pokemons.Count <= 0 || player._pokemons.Count <= 0)
                    {
                        currentState = TurnSys.WinLoseState;
                    }
                    else if (rival._pokemons[0] != null)
                    {
                        Destroy(rival._pokemons[0]);
                        rival._pokemons.RemoveAt(0);
                        dialogueSystem.GetComponent<SwapDialogue>().SwapRival();
                        rival._pokemons[0].SetActive(true);
                        currentState = TurnSys.PostAttackState;
                    }
                    else if (player._pokemons[0] != null)
                    {
                        Destroy(player._pokemons[0]);
                        player._pokemons.RemoveAt(0);
                        dialogueSystem.GetComponent<SwapDialogue>().SwapPlayer();
                        player._pokemons[0].SetActive(true);
                        currentState = TurnSys.PostAttackState;
                    }
                }

                break;
            case TurnSys.WinLoseState:
                if (rival._pokemons.Count <= 0)
                {
                    dialogueSystem.GetComponent<WinDialogue>().enabled = true;
                }
                else if (player._pokemons.Count <= 0)
                {
                    dialogueSystem.GetComponent<LoseDialogue>().enabled = true;
                }

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
        FeintState,
        WinLoseState
    }
}