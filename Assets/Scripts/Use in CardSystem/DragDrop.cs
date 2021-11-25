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
    public GameObject Card6;

    public GameObject Effect_01;
    public GameObject Effect_02;
    public GameObject Effect_03;
    public GameObject Effect_04;

    public GameObject PlayerMelee;
    public GameObject PlayerTank;
    public GameObject PlayerArcher;

    public GameObject Enemy;

    public float delayTime = 2f;
    private GameObject[] target;

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
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x > 9)
            {
                SceneManager.LoadScene(7);
            }
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

            if (this.gameObject==Card1)
            {
                DrawCards.handCount--;

                Vector3 localPosition = GetComponent<RectTransform>().position;
                GetComponent<RectTransform>().position = localPosition + new Vector3(0, 0, -1000);

                GameObject p = Instantiate(PlayerMelee);
                Effect_01.transform.position = PlayerMelee.transform.position;
                Effect_01.transform.position -= new Vector3(-0.8f, 1.14f, 0f);
                Effect_01.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 
                    PlayerMelee.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder + 1;

                StartCoroutine(CardEffect(Effect_01, p, 0.6f));
            }
            else if(this.gameObject == Card2)
            {
                DrawCards.handCount--;

                Vector3 localPosition = GetComponent<RectTransform>().position;
                GetComponent<RectTransform>().position = localPosition + new Vector3(0, 0, -1000);

                GameObject p = Instantiate(PlayerTank);
                Effect_01.transform.position = PlayerTank.transform.position;
                Effect_01.transform.position -= new Vector3(-0.8f, 1.14f, 0f);
                Effect_01.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                    PlayerTank.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder + 1;

                StartCoroutine(CardEffect(Effect_01, p, 0.6f));
            }
            else if (this.gameObject == Card3)
            {
                float damage;
                DrawCards.handCount--;

                Vector3 localPosition = GetComponent<RectTransform>().position;
                GetComponent<RectTransform>().position = localPosition + new Vector3(0, 0, -1000);

                target = GameObject.FindGameObjectsWithTag("Enemy");
                Debug.Log(target[0].name.Substring(0,9));
                if(target[0].name.Substring(0, 9) != "Boss_Loki")
                {
                    damage = target[0].GetComponent<NewEnemyCombat>().startHealth / 4;
                }
                else
                {
                    damage = 50.0f;
                }
                for(int i = 0; i < target.Length; i++)
                {
                    if (target[i].name.Substring(0, 9) != "Boss_Loki")
                    {
                        target[i].GetComponent<NewEnemyCombat>().OnDamage(damage);
                        Effect_02.transform.position = target[i].transform.position;
                        Effect_02.transform.position -= new Vector3(-1.0f, 0.6f, 0f);
                        Effect_02.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                            target[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder + 1;
                        StartCoroutine(CardEffect(Effect_02, target[i], 0.9f));
                        target[i] = null;
                    }
                    else
                    {
                        target[i].GetComponent<BossCombat>().OnDamage(damage);
                        Effect_02.transform.position = target[i].transform.position;
                        Effect_02.transform.position -= new Vector3(-1.5f, 0.6f, 0f);
                        Effect_02.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                            target[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder + 1;
                        Vector3 localScale = Effect_02.transform.localScale;
                        Effect_02.transform.localScale *= 2.0f;
                        StartCoroutine(CardEffect(Effect_02, target[i], 0.9f));
                        Effect_02.transform.localScale = localScale;
                        target[i] = null;
                    }                                                
                }
            }
            else if(this.gameObject == Card4)
            {
                DrawCards.handCount--;

                Vector3 localPosition = GetComponent<RectTransform>().position;
                GetComponent<RectTransform>().position = localPosition + new Vector3(0, 0, -1000);

                target = GameObject.FindGameObjectsWithTag("Player");
                for(int i = 0; i <target.Length; i++)
                {
                    target[i].GetComponent<NewPlayerCombat>().RestoreHearth(50.0f);
                    Effect_03.transform.position = target[i].transform.position;
                    Effect_03.transform.position -= new Vector3(-0.8f, 1.14f, 0f);
                    Effect_02.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                        target[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder + 1;
                    StartCoroutine(CardEffect(Effect_03, target[i], 0.7f));
                    target[i] = null;
                }           
            }
            else if(this.gameObject == Card5)
            {
                DrawCards.handCount--;
                Vector3 localPosition = GetComponent<RectTransform>().position;
                GetComponent<RectTransform>().position = localPosition + new Vector3(0, 0, -1000);

                StartCoroutine(Card5_Delay(2.0f));
            }
            else if (this.gameObject == Card6)
            {
                DrawCards.handCount--;

                Vector3 localPosition = GetComponent<RectTransform>().position;
                GetComponent<RectTransform>().position = localPosition + new Vector3(0, 0, -1000);

                GameObject p = Instantiate(PlayerArcher);
                Effect_01.transform.position = PlayerArcher.transform.position;
                Effect_01.transform.position -= new Vector3(-0.8f, 1.14f, 0f);
                Effect_01.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                    PlayerArcher.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder + 1;

                StartCoroutine(CardEffect(Effect_01, p, 0.6f));
            }

        }
        else
        {
            transform.position = startPosition;
        }
    }
    public IEnumerator Card5_Delay(float delay)
    {
        target = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] e = new GameObject[target.Length];
        for (int i = 0; i < target.Length; i++)
        {
            target[i].GetComponent<NewEnemyCombat>().isStuck = true;
            

            Effect_04.transform.position = target[i].transform.position;
            Effect_04.transform.position -= new Vector3(-1.3f, 0.7f, 0f);
            Effect_04.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                target[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder + 1;

            e[i] = Instantiate(Effect_04);
            e[i].transform.SetParent(target[i].transform);
        }

        yield return new WaitForSeconds(delay);

        for (int i = 0; i < target.Length; i++)
        {
            target[i].GetComponent<NewEnemyCombat>().isStuck = false;
            
            Destroy(e[i]);
        }

        Destroy(this.gameObject);
    }
    IEnumerator CardEffect(GameObject effect, GameObject target, float delay)
    {

        GameObject e = Instantiate(effect);
        e.transform.SetParent(target.transform);
       
        yield return new WaitForSeconds(delay);

        GameObject[] ef = GameObject.FindGameObjectsWithTag("Bless");
        for(int i = 0; i < ef.Length; i++)
        {
            Destroy(ef[i]);
        }  
        Destroy(this.gameObject);
    }
}
