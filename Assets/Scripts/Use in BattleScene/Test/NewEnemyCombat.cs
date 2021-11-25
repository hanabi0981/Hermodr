using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEnemyCombat : LifeEntity
{
    public float moveSpeed;
    public float damage;
    public float attackRange;
    public float timeBetAttack;
    private float lastAttackTime;

    public Slider healthBar;
    public Gradient gradient;
    public Image fill;
    Animator animator;

    public LayerMask Target;
    public float moveRange;

    ObjectGenerator og;
    private int killCount;
    private void Start()
    {
        og = GameObject.FindObjectOfType<ObjectGenerator>().GetComponent<ObjectGenerator>();
        animator = GetComponentInChildren<Animator>();
        healthBar.maxValue = startHealth;
        healthBar.value = health;
        fill.color = gradient.Evaluate(1f);
        float rand = UnityEngine.Random.Range(-0.3f, 0.3f);
        attackRange += (float) Math.Truncate(rand * 100) / 100;
        moveRange = attackRange;
        lastAttackTime = 0;
    }
    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange, Target);
        RaycastHit2D hit= Physics2D.Raycast(transform.position, -1 * transform.right, moveRange);
       
        if(!isDead)
        {
            if(!isStuck)
            {
                if (colliders.Length != 0)
                {
                    if (colliders[0].tag == "Player" || colliders[0].tag == "Nexus")
                    {
                        Attack(colliders);
                    }
                    else
                    {
                        animator.SetBool("Move", false);
                        Idle();
                    }
                }
                else if (hit.collider == null)
                {
                    animator.SetBool("Move", true);
                    Move();
                }
            }
        }
    }
    private void Move()
    {
        Vector2 moveDistance = -1 * transform.right * Time.deltaTime * moveSpeed;
        transform.Translate(moveDistance);
    }
    private void Attack(Collider2D[] c)
    {
        if(c.Length != 0)
        {
            if (Time.time >= lastAttackTime + timeBetAttack)
            {
                animator.SetBool("Move", true);
                animator.SetTrigger("Attack");
                lastAttackTime = Time.time;
                IDamageable[] target = new IDamageable[c.Length];
                for (int i = 0; i < c.Length; i++)
                {
                    target[i] = c[i].GetComponent<IDamageable>();
                    if (target[i] != null)
                    {
                        target[i].OnDamage(damage);
                        break;
                    }
                }
            }
            else
            {
                animator.SetBool("Move", false);
                Idle();
            }
        }
        else
        {
            animator.SetBool("Move", false);
            Idle();
        }
    }
    private void Idle()
    {
        ;
    }
    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        healthBar.value = health;
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
    public override void Die()
    {
        base.Die();
        healthBar.gameObject.SetActive(false);
        gameObject.tag = "Finish";
        animator.SetTrigger("D");
        Destroy(gameObject, 1.0f);
        ObjectGenerator.killcount++;
        killCount++;
        og.remainEnemy--;
        PlayerPrefs.SetInt("killCount", killCount);
    }
}
