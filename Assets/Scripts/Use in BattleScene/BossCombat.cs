using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCombat : LifeEntity
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

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        healthBar.maxValue = startHealth;
        healthBar.value = health;
        fill.color = gradient.Evaluate(1f);
        lastAttackTime = 0;
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -1 * transform.right, attackRange);
        if(!isDead)
        {
            if(hit.collider == null)
            {
                animator.SetBool("Move", true);
                Move();
            }
            else if(hit.collider.tag == "Player" || hit.collider.tag == "Nexus")
            {
                AttackReady(hit);
            }
            else
            {
                animator.SetBool("Move", false);
                Idle();
            }
        }
    }
    private void Move()
    {
        Vector2 moveDistance = -1 * transform.right * Time.deltaTime * moveSpeed;
        transform.Translate(moveDistance);
    }
    private void AttackReady(RaycastHit2D h)
    {
        if(Time.time >= lastAttackTime + timeBetAttack)
        {
            animator.SetBool("Move", true);
            IDamageable target = h.collider.GetComponent<IDamageable>();
            if(target != null)
            {
                animator.SetBool("AttackReady", true);
                StartCoroutine(Attack(target));
            }
        }
        else
        {
            animator.SetBool("Move", false);
            Idle();
        }
    }
    private IEnumerator Attack(IDamageable t)
    {
        lastAttackTime = Time.time;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        animator.SetTrigger("Attack");
        t.OnDamage(damage);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        lastAttackTime = Time.time;
        animator.SetBool("AttackReady", false);
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
        animator.SetTrigger("Die");
        Destroy(gameObject, 1.0f);
    }
}
