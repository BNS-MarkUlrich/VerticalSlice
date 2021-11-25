using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] public int _curHealth;

    void Start()
    {
        _curHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
    }

    protected virtual void TakeDamage(int damageTaken)
    {
        _curHealth -= damageTaken;

        if (_curHealth <= 0)
        {
            Faint();
        }
    }

    protected virtual void Faint()
    {
        // Doe hier de Faint dingen
        Debug.Log("Ik faint");
    }
}
