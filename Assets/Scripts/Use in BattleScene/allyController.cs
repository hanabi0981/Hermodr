using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allyController : MonoBehaviour
{
    float speed = 2f;
    public int power = 40;
    public int maxHealth = 100;
    public int currentHealth;

    float delayTime;

    bool isMove;
    bool isAttack;
    bool engage;

    Animator animator;
    EnemyController enemyController;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        isMove = false;
        isAttack = false;
        engage = false;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Move()
    {
        animator.SetBool("Move", true);
    }
    void Attack()
    {
        animator.SetBool("Attack", true);
        DoDamage();
        isMove = true;
        isAttack = true;
    }
    void Stop()
    {
        animator.SetBool("Attack", false); // 애니메이션 Idle 재생
        if(engage)
        {
            animator.SetBool("Move", false); // 교전 중이면 Move로 가지않게,
            isMove = true;
        }
        else
        {
            animator.SetBool("Move", true); // 교전 중이 아니라면 Move로 가게끔.
            isMove = false;
        }
        isAttack = false;
        
    }
    public void Die()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.55f);
    }
    private void Update()
    {
        if (!isMove)
        {
            Move();
            transform.Translate(Time.deltaTime * speed * Vector3.right);
        }
        if (isAttack)
        {
            delayTime += Time.deltaTime;
            if (delayTime >= 0.4f)
            {
                Stop();
                delayTime = 0;
            }
        }
        if(engage)
        {
            delayTime += Time.deltaTime;
            if (delayTime >= 1.0f)
            {
                Attack();
                delayTime = 0;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemyController = collision.gameObject.GetComponent<EnemyController>();

        if (collision.gameObject.tag == "Enemy")
        {
            Attack();
            engage = true;
        }
    }
    public void DoDamage()
    {
        if (enemyController.currentHealth != 0)
        {
            enemyController.currentHealth -= power;
            enemyController.healthBar.SetHealth(enemyController.currentHealth);
            if (enemyController.currentHealth <= 0)
            {
                enemyController.Die();
                engage = false;
            }
        }
    }
}
