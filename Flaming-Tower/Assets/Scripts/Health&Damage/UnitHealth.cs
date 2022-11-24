using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    // Fields
    [Header("Health Settings")]
    [Tooltip("The default health value")]
    public int startingHealth = 1;
    [Tooltip("The maximum health value")]
    public int maxHealth = 1;
    
    private int _currentHealth;
    private int _currentMaxHealth;
    
    // Properties
    public int Health {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }
    
    public int MaxHealth {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }
    
    // Constructor
    public UnitHealth()
    {
        _currentHealth = startingHealth;
        _currentMaxHealth = maxHealth;
    }
    
    // Methods
    public void DamageUnit(int damageAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damageAmount;

            if (_currentHealth == 0)
            {
                GameManager.gameManager.ShowGameOverScreen();
            }
            
        }
        
        GameManager.gameManager.ShowGameOverScreen();
    }
    
    public void HealUnit(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }

        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
