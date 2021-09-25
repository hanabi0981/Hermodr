using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int speed = 5;
    public int power = 20;
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject ally;
    allyController allyController;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        allyController = ally.GetComponent<allyController>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(allyController.power);
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
            transform.position += Vector3.right * 3;
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
