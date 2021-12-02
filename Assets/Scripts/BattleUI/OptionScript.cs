using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionScript : MonoBehaviour
{
    private int optionsMenu;
    private bool fight;
    private bool bag;
    private bool pokemon;
    private bool run;
    private bool go;

    [SerializeField] private GameObject arrowFight;
    [SerializeField] private GameObject arrowBag;
    [SerializeField] private GameObject arrowPokemon;
    [SerializeField] private GameObject arrowRun;


    public FightUI currentSelection = FightUI.FIGHT;

    private void Start()
    {
        fight = true;
        go = true;
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
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentSelection = FightUI.BAG;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentSelection = FightUI.BAG;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentSelection = FightUI.POKEMON;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    currentSelection = FightUI.POKEMON;
                }
                break;
            case FightUI.BAG:
                arrowFight.gameObject.SetActive(false);
                arrowPokemon.gameObject.SetActive(false);
                arrowBag.gameObject.SetActive(true);
                arrowRun.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentSelection = FightUI.FIGHT;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentSelection = FightUI.FIGHT;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentSelection = FightUI.RUN;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    currentSelection = FightUI.RUN;
                }
                break;
            case FightUI.POKEMON:
                arrowFight.gameObject.SetActive(false);
                arrowPokemon.gameObject.SetActive(true);
                arrowBag.gameObject.SetActive(false);
                arrowRun.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentSelection = FightUI.RUN;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentSelection = FightUI.RUN;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentSelection = FightUI.FIGHT;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    currentSelection = FightUI.FIGHT;
                }
                break;
            case FightUI.RUN:
                arrowFight.gameObject.SetActive(false);
                arrowPokemon.gameObject.SetActive(false);
                arrowBag.gameObject.SetActive(false);
                arrowRun.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentSelection = FightUI.POKEMON;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentSelection = FightUI.POKEMON;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentSelection = FightUI.BAG;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    currentSelection = FightUI.BAG;
                }
                break;
        }
    }

    public enum FightUI
    {
        FIGHT,
        POKEMON,
        BAG,
        RUN
    }
}
