using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class handles the player/units health.
/// </summary>
public class UnitHealth : MonoBehaviour
{
    // Fields
    [Header("Health Settings")]
    [Tooltip("The default health value")]
    public int startingHealth = 1;
    [Tooltip("The maximum health value")]
    public int maxHealth = 1;
    [Tooltip("The players current health.")]
    private int _currentHealth;
    [Tooltip("The maximum health the player can possibly have.")]
    private int _currentMaxHealth;
    
    // Properties
    /// <summary>
    /// Either returns the players health or sets the players health.
    /// </summary>
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
    /// <summary>
    /// Either returns the players max health or sets the players max health.
    /// </summary>
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
    
    // Constructor.
    public UnitHealth()
    {
        _currentHealth = startingHealth;
        _currentMaxHealth = maxHealth;
    }

    // Methods.

    /// <summary>
    /// Damages the player by specified amount.
    /// If the player reaches 0 health
    /// an game over screen will be displayed.
    /// </summary>
    /// <param name="damageAmount"></param>
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
    /// <summary>
    /// Heals the player.
    /// </summary>
    /// <param name="healAmount"></param>
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
