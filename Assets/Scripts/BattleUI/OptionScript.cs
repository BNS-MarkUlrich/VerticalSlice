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
    [SerializeField] private GameObject fightOptions;
    [SerializeField] private GameObject arrowTackle;
    [SerializeField] private GameObject arrowGrowl;
    private int options;

    public FightUI currentSelection = FightUI.FIGHT;
    public MoveUI currenMove = MoveUI.TACKLE;
    private void Start()
    {
        fightOptions.gameObject.SetActive(false);
        options = 1;
    }
    private void Update()
    {

        switch (currentSelection)
        {
            case FightUI.FIGHT:
                arrowFight.gameObject.SetActive(true);
                arrowBag.gameObject.SetActive(false);
                arrowPokemon.gameObject.SetActive(false);
                arrowRun.gameObject.SetActive(false);

                if (Input.GetKeyDown(KeyCode.RightArrow) && options == 1)
                {
                    currentSelection = FightUI.BAG;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && options == 1)
                {
                    currentSelection = FightUI.BAG;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && options == 1)
                {
                    currentSelection = FightUI.POKEMON;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && options == 1)
                {
                    currentSelection = FightUI.POKEMON;
                }
                else if (Input.GetKeyDown(KeyCode.X) && options == 1)
                {
                    fightOptions.gameObject.SetActive(true);
                    options = 2;
                }
                break;
            case FightUI.BAG:
                arrowFight.gameObject.SetActive(false);
                arrowPokemon.gameObject.SetActive(false);
                arrowBag.gameObject.SetActive(true);
                arrowRun.gameObject.SetActive(false);
                fightOptions.gameObject.SetActive(false);

                if (Input.GetKeyDown(KeyCode.RightArrow) && options == 1)
                {
                    currentSelection = FightUI.FIGHT;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && options == 1)
                {
                    currentSelection = FightUI.FIGHT;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && options == 1)
                {
                    currentSelection = FightUI.RUN;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && options == 1)
                {
                    currentSelection = FightUI.RUN;
                }
                break;
            case FightUI.POKEMON:
                arrowFight.gameObject.SetActive(false);
                arrowPokemon.gameObject.SetActive(true);
                arrowBag.gameObject.SetActive(false);
                arrowRun.gameObject.SetActive(false);
                fightOptions.gameObject.SetActive(false);

                if (Input.GetKeyDown(KeyCode.RightArrow) && options == 1)
                {
                    currentSelection = FightUI.RUN;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && options == 1)
                {
                    currentSelection = FightUI.RUN;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && options == 1)
                {
                    currentSelection = FightUI.FIGHT;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && options == 1)
                {
                    currentSelection = FightUI.FIGHT;
                }
                break;
            case FightUI.RUN:
                arrowFight.gameObject.SetActive(false);
                arrowPokemon.gameObject.SetActive(false);
                arrowBag.gameObject.SetActive(false);
                arrowRun.gameObject.SetActive(true);
                fightOptions.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.RightArrow) && options == 1)
                {
                    currentSelection = FightUI.POKEMON;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && options == 1)
                {
                    currentSelection = FightUI.POKEMON;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && options == 1)
                {
                    currentSelection = FightUI.BAG;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && options == 1)
                {
                    currentSelection = FightUI.BAG;
                }
                break;
        }
        switch (currenMove)
        {
            case MoveUI.TACKLE:
                arrowTackle.gameObject.SetActive(true);
                arrowGrowl.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.RightArrow) && options == 3)
                {
                    currenMove = MoveUI.GROWL;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && options == 3)
                {
                    currenMove = MoveUI.GROWL;
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
                else if (Input.GetKeyDown(KeyCode.X) && options == 3)
                {
                    Debug.Log("bulbasaur used tackle");
                }
                break;
            case MoveUI.GROWL:
                arrowTackle.gameObject.SetActive(false);
                arrowGrowl.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.RightArrow) && options == 3)
                {
                    currenMove = MoveUI.TACKLE;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && options == 3)
                {
                    currenMove = MoveUI.TACKLE;
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && options == 3)
                {
                    fightOptions.gameObject.SetActive(false);
                    currenMove = MoveUI.TACKLE;
                    options = 1;
                }
                else if (Input.GetKeyDown(KeyCode.X) && options == 3)
                {
                    Debug.Log("bulbasaur used growl");
                }
                break;
        }
    }

    public enum FightUI
    {
        FIGHT,
        POKEMON,
        BAG,
        RUN,
    }
    public enum MoveUI
    {
        TACKLE,
        GROWL
    }
}
