using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    protected int _dmgValue;
    protected int _accuracy;

    protected int _ppMax;
    protected int _ppAmount;

    protected string _moveType;

    public abstract void Attack();
}