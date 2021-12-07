using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionScript : MonoBehaviour
{
    [SerializeField] private GameObject arrowFight;
    [SerializeField] private GameObject arrowBag;
    [SerializeField] private GameObject arrowPokemon;
    [SerializeField] private GameObject arrowRun;
    [SerializeField] public  GameObject optionsMenu;
    [SerializeField] private GameObject fightOptions;
    [SerializeField] private GameObject arrowAttack1;
    [SerializeField] private GameObject arrowAttack2;
    [SerializeField] private GameObject arrowAttack3;
    [SerializeField] private GameObject arrowAttack4;

    [SerializeField] private Text textPP;
    [SerializeField] private Text[] attackTexts;
    [SerializeField] private BaseAttack[] attacks;
    [SerializeField] private PokeTeam pokeTeam;
    private GameObject pokemon;
    private int amountPP1;
    private int amountPP2;
    private int amountPP3;
    private int amountPP4;

    private int options;

    public FightUI currentSelection = FightUI.FIGHT;
    public MoveUI currenMove = MoveUI.Attack1;

    private bool turnSystemControls;
    private void Start()
    {
        fightOptions.gameObject.SetActive(false);
        options = 1;
        arrowFight.gameObject.SetActive(true);
        arrowAttack1.gameObject.SetActive(true);
    }
    private void Update()
    {
        pokemon = pokeTeam.GetComponent<PokeTeam>()._pokemons[0];
        attacks = pokemon.GetComponent<BasePokemon>().attacks;
        turnSystemControls = FindObjectOfType<TurnSystem>().controls;
        if (turnSystemControls)
        {
            // navigating the main menu 
            switch (currentSelection)
            {
                case FightUI.FIGHT:
                    if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && options == 1)
                    {
                        currentSelection = FightUI.BAG;
                        arrowBag.gameObject.SetActive(true);
                        arrowFight.gameObject.SetActive(false);
                    }
                    else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && options == 1)
                    {
                        currentSelection = FightUI.POKEMON;
                        arrowFight.gameObject.SetActive(false);
                        arrowPokemon.gameObject.SetActive(true);
                    }

                    else if (Input.GetKeyDown(KeyCode.X) && options == 1)
                    {
                        fightOptions.gameObject.SetActive(true);

                        for (int i = 0; i < 4; i++)
                        {
                            if (attacks.Length <= i)
                            {
                                attackTexts[i].text = "-";
                            }
                            else
                            {
                                attackTexts[i].text = attacks[i].name.ToUpper();

                            }
                        }

                        options = 2;
                    }
                    break;

                case FightUI.BAG:
                    if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && options == 1)
                    {
                        currentSelection = FightUI.FIGHT;
                        arrowBag.gameObject.SetActive(false);
                        arrowFight.gameObject.SetActive(true);
                    }
                    else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && options == 1)
                    {
                        currentSelection = FightUI.RUN;
                        arrowBag.gameObject.SetActive(false);
                        arrowRun.gameObject.SetActive(true);
                    }
                    break;

                case FightUI.POKEMON:
                    if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && options == 1)
                    {
                        currentSelection = FightUI.RUN;
                        arrowPokemon.gameObject.SetActive(false);
                        arrowRun.gameObject.SetActive(true);
                    }
                    else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && options == 1)
                    {
                        currentSelection = FightUI.FIGHT;
                        arrowPokemon.gameObject.SetActive(false);
                        arrowFight.gameObject.SetActive(true);
                    }
                    break;

                case FightUI.RUN:
                    if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && options == 1)
                    {
                        currentSelection = FightUI.POKEMON;
                        arrowRun.gameObject.SetActive(false);
                        arrowPokemon.gameObject.SetActive(true);
                    }
                    else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && options == 1)
                    {
                        currentSelection = FightUI.BAG;
                        arrowRun.gameObject.SetActive(false);
                        arrowBag.gameObject.SetActive(true);
                    }
                    break;
            }



            // navigating the moves
            switch (currenMove)
            {
                case MoveUI.Attack1:
                    int amountPPAttack1;
                    amountPP1 = attacks[0].GetComponent<BaseAttack>()._ppMax;
                    amountPPAttack1 = attacks[0].GetComponent<BaseAttack>()._ppAmount;
                    textPP.text = amountPPAttack1 + "/" + amountPP1;

                    if (attacks.Length >= 2 && options == 3 && options == 3 && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
                    {
                        currenMove = MoveUI.Attack2;
                        arrowAttack1.gameObject.SetActive(false);
                        arrowAttack2.gameObject.SetActive(true);
                    }
                    else if (attacks.Length >= 3 && options == 3 && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
                    {
                        currenMove = MoveUI.Attack3;
                        arrowAttack1.gameObject.SetActive(false);
                        arrowAttack3.gameObject.SetActive(true);
                    }

                    else if (Input.GetKeyDown(KeyCode.Escape) && options == 3)
                    {
                        fightOptions.gameObject.SetActive(false);
                        options = 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && options == 2)
                    {
                        options = 3;
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && options == 3 && amountPPAttack1 >= 1)
                    {
                        if (attacks[0] != null && attacks.Length > 0)
                        {
                            // Mark Begin
                            //attacks[0].Attack();
                            FindObjectOfType<TurnSystem>().attackTurns.Add(attacks[0]);
                            // Mark End
                        }
                        // Mark Begin
                        fightOptions.gameObject.SetActive(false);
                        options = 1;
                        FindObjectOfType<TurnSystem>().currentState = TurnSystem.TurnSys.RivalAttackState;
                        //Debug.Log("bulbasaur used " + attacks[0].name); // Mark Edit
                        // Mark End
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && amountPPAttack1 <= 0)
                    {
                        Debug.Log("don't have enough for tackle");
                    }


                    break;

                case MoveUI.Attack2:
                    arrowAttack1.gameObject.SetActive(false);
                    arrowAttack2.gameObject.SetActive(true);
                    int amountPPAttack2;
                    amountPP2 = attacks[1].GetComponent<BaseAttack>()._ppMax;
                    amountPPAttack2 = attacks[1].GetComponent<BaseAttack>()._ppAmount;
                    textPP.text = amountPPAttack2 + "/" + amountPP2;
                    if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && options == 3)
                    {
                        currenMove = MoveUI.Attack1;
                        arrowAttack2.gameObject.SetActive(false);
                        arrowAttack1.gameObject.SetActive(true);

                    }
                    else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && options == 3 && attacks.Length >= 4)
                    {
                        currenMove = MoveUI.Attack4;
                        arrowAttack2.gameObject.SetActive(false);
                        arrowAttack4.gameObject.SetActive(true);
                    }
                    else if (Input.GetKeyDown(KeyCode.Escape) && options == 3)
                    {
                        currenMove = MoveUI.Attack1;
                        fightOptions.gameObject.SetActive(false);
                        arrowAttack2.gameObject.SetActive(false);
                        arrowAttack1.gameObject.SetActive(true);
                        options = 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && options == 3 && amountPPAttack2 >= 1)
                    {
                        if (attacks[1] != null && attacks.Length > 0)
                        {
                            // Mark Begin
                            //attacks[1].Attack();
                            FindObjectOfType<TurnSystem>().attackTurns.Add(attacks[1]);
                            // Mark End
                        }
                        // Mark Begin
                        fightOptions.gameObject.SetActive(false);
                        arrowAttack2.gameObject.SetActive(false);
                        arrowAttack1.gameObject.SetActive(true);
                        currenMove = MoveUI.Attack1;
                        options = 1;
                        FindObjectOfType<TurnSystem>().currentState = TurnSystem.TurnSys.RivalAttackState;
                        //Debug.Log("bulbasaur used " + attacks[1].name); // Mark Edit
                        // Mark End
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && amountPPAttack2 <= 0)
                    {
                        Debug.Log("don't have enough for growl");
                    }
                    break;

                case MoveUI.Attack3:
                    int amountPPAttack3;
                    amountPP2 = attacks[2].GetComponent<BaseAttack>()._ppMax;
                    amountPPAttack3 = attacks[2].GetComponent<BaseAttack>()._ppAmount;
                    textPP.text = amountPPAttack3 + "/" + amountPP2;
                    if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && options == 3 && attacks.Length >= 4)
                    {
                        currenMove = MoveUI.Attack4;
                        arrowAttack3.gameObject.SetActive(false);
                        arrowAttack4.gameObject.SetActive(true);
                    }
                    else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && options == 3)
                    {
                        currenMove = MoveUI.Attack1;
                        arrowAttack3.gameObject.SetActive(false);
                        arrowAttack1.gameObject.SetActive(true);
                    }
                    else if (Input.GetKeyDown(KeyCode.Escape) && options == 3)
                    {
                        fightOptions.gameObject.SetActive(false);
                        arrowAttack3.gameObject.SetActive(false);
                        arrowAttack1.gameObject.SetActive(true);
                        currenMove = MoveUI.Attack1;
                        options = 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && options == 3 && amountPPAttack3 >= 1)
                    {
                        if (attacks[2] != null && attacks.Length > 0)
                        {
                            // Mark Begin
                            //attacks[2].Attack();
                            FindObjectOfType<TurnSystem>().attackTurns.Add(attacks[2]);
                            // Mark End
                        }
                        // Mark Begin
                        fightOptions.gameObject.SetActive(false);
                        arrowAttack3.gameObject.SetActive(false);
                        arrowAttack1.gameObject.SetActive(true);
                        currenMove = MoveUI.Attack1;
                        options = 1;
                        FindObjectOfType<TurnSystem>().currentState = TurnSystem.TurnSys.RivalAttackState;
                        //Debug.Log("bulbasaur used " + attacks[2].name); // Mark Edit
                        // Mark End
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && amountPPAttack3 <= 0)
                    {
                        Debug.Log("don't have enough for growl");
                    }
                    break;

                case MoveUI.Attack4:
                    int amountPPAttack4;
                    amountPP2 = attacks[3].GetComponent<BaseAttack>()._ppMax;
                    amountPPAttack4 = attacks[3].GetComponent<BaseAttack>()._ppAmount;
                    textPP.text = amountPPAttack4 + "/" + amountPP2;
                    if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && options == 3)
                    {
                        currenMove = MoveUI.Attack3;
                        arrowAttack4.gameObject.SetActive(false);
                        arrowAttack3.gameObject.SetActive(true);
                    }
                    if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && options == 3)
                    {
                        currenMove = MoveUI.Attack2;
                        arrowAttack4.gameObject.SetActive(false);
                        arrowAttack2.gameObject.SetActive(true);
                    }
                    else if (Input.GetKeyDown(KeyCode.Escape) && options == 3)
                    {
                        fightOptions.gameObject.SetActive(false);
                        arrowAttack4.gameObject.SetActive(false);
                        arrowAttack1.gameObject.SetActive(true);
                        currenMove = MoveUI.Attack1;
                        options = 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && options == 3 && amountPPAttack4 >= 1)
                    {
                        if (attacks[3] != null && attacks.Length > 0)
                        {
                            // Mark Begin
                            //attacks[3].Attack();
                            FindObjectOfType<TurnSystem>().attackTurns.Add(attacks[3]);
                            // Mark End
                        }
                        // Mark Begin
                        fightOptions.gameObject.SetActive(false);
                        arrowAttack4.gameObject.SetActive(false);
                        arrowAttack1.gameObject.SetActive(true);
                        currenMove = MoveUI.Attack1;
                        options = 1;
                        FindObjectOfType<TurnSystem>().currentState = TurnSystem.TurnSys.RivalAttackState;
                        //Debug.Log("bulbasaur used " + attacks[3].name); // Mark Edit
                        // Mark End
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && amountPPAttack4 <= 0)
                    {
                        Debug.Log("don't have enough for growl");
                    }
                    break;
            }
        }
        
    }
    // all the options of main menu
    public enum FightUI
    {
        FIGHT,
        POKEMON,
        BAG,
        RUN,
    }
    // all the options of the moves
    public enum MoveUI
    {
        Attack1,
        Attack2,
        Attack3,
        Attack4
    }
}