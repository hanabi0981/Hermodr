using System;
using UnityEngine;

public class LifeEntity : MonoBehaviour, IDamageable
{
    public float startHealth = 100f;
    public float health { get; set; }
    public bool isDead { get; set; }
    virtual protected void OnEnable()
    {
        isDead = false;
        health = startHealth;
    }
    virtual public void OnDamage(float damage)
    {
        health -= damage;
        if(health <= 0 && !isDead)
        {
            Die();
        }
    }
    virtual public void Die()
    {
        isDead = true;
    }

}
