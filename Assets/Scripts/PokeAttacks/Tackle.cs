using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : MonoBehaviour
{
    public int dmgValue;
    public int accuracy;

    public GameObject target;

    private int maxPP = 35;
    [SerializeField] public int ppAmount { get; private set; }



    public void TackleAttack()
    {
        int totalDamage = dmgValue;
        int hitOrMiss = Random.Range(1, 100);

        if (hitOrMiss <= accuracy)
        {
            target.GetComponent<BaseHealthScript>().TakeDamage(totalDamage);
        }
        else
        {
            Debug.Log("Attack Missed");
        }
        ppAmount -= 1;
    }
}