using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allyController : MonoBehaviour
{
    int speed = 5;
    public int power = 40;
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject enermy;
    EnemyController enemyController;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = enermy.GetComponent<EnemyController>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(enemyController.power);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(0.01f * speed, 0, 0);
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth != 0)
        {
            transform.position += Vector3.left * 3;
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
