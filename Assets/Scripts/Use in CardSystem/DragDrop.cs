using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;

    public GameObject Player;
    public GameObject Enemy;

    public float delayTime = 2f;
    private GameObject target;

    private bool isDragging = false;
    private bool isOverDropArea = false;
    private GameObject dropArea;
    private Vector2 startPosition;


    // Update is called once per frame sub
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if(GameObject.FindGameObjectWithTag("Player").transform.position.x > 9)
        {
            SceneManager.LoadScene(7);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropArea = true;
        dropArea = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropArea = false;
        dropArea = null;
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropArea)
        {
            transform.SetParent(dropArea.transform, false);

            if (this.gameObject==Card1||this.gameObject==Card2)
            {
                Destroy(this.gameObject);
                Instantiate(Player);
            }
            else if (this.gameObject == Card3)
            {
                Destroy(this.gameObject);
                target = GameObject.FindGameObjectWithTag("Enemy");
                target.GetComponent<EnemyCombat>().health = target.GetComponent<EnemyCombat>().health - 50;
                target.GetComponent<EnemyCombat>().healthBar.value = target.GetComponent<EnemyCombat>().health;
                target = null;
            }
            else if(this.gameObject == Card4)
            {
                Destroy(this.gameObject);
                target = GameObject.FindGameObjectWithTag("Player");
                target.GetComponent<PlayerCombat>().health = target.GetComponent<PlayerCombat>().health + 50;
                target.GetComponent<PlayerCombat>().healthBar.value = target.GetComponent<PlayerCombat>().health;
                target = null;
            }
            else if(this.gameObject == Card5)
            {
                Destroy(this.gameObject);
                target = GameObject.FindGameObjectWithTag("Enemy");
                target.GetComponent<EnemyCombat>().moveSpeed = 0;
                StartCoroutine(CountMagicDelay());
                target = null;
            }

        }
        else
        {
            transform.position = startPosition;
        }
    }

    IEnumerator CountMagicDelay()
    {
        yield return new WaitForSeconds(delayTime);
        target.GetComponent<EnemyCombat>().moveSpeed = 1;
    }
}
