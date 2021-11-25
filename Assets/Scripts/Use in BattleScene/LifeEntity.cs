using System;
using UnityEngine;

public class LifeEntity : MonoBehaviour, IDamageable
{
    public float startHealth = 100f;
    public float health { get; set; }
    public bool isDead { get; set; }
    public bool isStuck { get; set; }
    virtual protected void OnEnable()
    {
        isDead = false;
        isStuck = false;
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
    virtual public void RestoreHearth(float restore)
    {
        health += restore;
        if(health > startHealth)
        {
            health = startHealth;
        }
    }
    virtual public void Die()
    {
        if(!isStuck)
        {
            isDead = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
    }

}
