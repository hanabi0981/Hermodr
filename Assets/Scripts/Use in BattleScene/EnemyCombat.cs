using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : LifeEntity
{
    public float moveSpeed = 5f;
    public float damage = 50;
    private float attackRange = 0.6f;
    public float timeBetAttack;
    private float lastAttackTime;

    public Slider healthBar;
    public Gradient gradient;
    public Image fill;
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        healthBar.maxValue = startHealth;
        healthBar.value = health;
        fill.color = gradient.Evaluate(1f);
        lastAttackTime = 0;
    }
    public void Attack(RaycastHit2D h)
    {
        if (Time.time >= lastAttackTime + timeBetAttack)
        {
            animator.SetTrigger("Attack");
            lastAttackTime = Time.time;
            IDamageable target = h.collider.GetComponent<IDamageable>();
            if (target != null)
            {
                target.OnDamage(damage);
            }
        }
    }
    private void Move()
    {
        Vector2 moveDistance = -1 * transform.right * Time.deltaTime * moveSpeed;
        transform.Translate(moveDistance);
    }
    void Stop()
    {
        ;
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, attackRange);
        if (!isDead)
        {
            if (hit.collider == null)
            {
                animator.SetBool("Move", true);
                Move();
            }
            else if (hit.collider.gameObject.tag == "Player")
            {
                Attack(hit);
            }
            else
            {
                animator.SetBool("Move", false);
                Stop();
            }
        }
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
    }
}
