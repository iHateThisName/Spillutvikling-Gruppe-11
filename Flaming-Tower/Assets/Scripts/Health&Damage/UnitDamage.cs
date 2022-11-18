using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    [Tooltip("How much damage to deal")]
    public int damageAmount = 1;

    [Tooltip("Whether or not to apply damage on non-trigger collider collisions")]
    public bool dealDamageOnCollision = true;

    private void DealDamage(GameObject collisionGameObject)
    {
        UnitHealth collidedHealth = collisionGameObject.GetComponent<UnitHealth>();

        // a different way to get health
        //int playerHeath = GameManager.gameManager.playerHealth.Health;

        if (collidedHealth.Health > 0)
        {
            //a different way to deal dmg to player
            //GameManager.gameManager.playerHealth.DamageUnit(damageAmount);
            collidedHealth.DamageUnit(damageAmount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (dealDamageOnCollision)
        {
            DealDamage(collision2D.gameObject);
        }
    }
}
