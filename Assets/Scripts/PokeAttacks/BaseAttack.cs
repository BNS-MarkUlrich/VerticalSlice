using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    protected int _dmgValue;
    protected int _accuracy;

    public int _ppMax; //{ get; protected set; }
    public int _ppAmount; //{ get; protected set; }

    protected string _moveType;

    public abstract void Attack();
}