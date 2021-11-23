using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{
    public GameObject Card1, Card2, Card3, Card4, Card5;
    public GameObject myHandArea;

    List<GameObject> cards = new List<GameObject>();

    private string draw = "Draw";

    public static int handCount=0;

    // Start is called before the first frame update
    void Start()
    {
        cards.Add(Card1); cards.Add(Card1); cards.Add(Card2); cards.Add(Card2); cards.Add(Card3);
        cards.Add(Card3); cards.Add(Card3); cards.Add(Card4); cards.Add(Card4); cards.Add(Card5);
    }
    public void Draw()
    {
        SoundManager.instance.PlaySE(draw);

        if(cards.Count != 0)
        {            
            if (cards.Count >= 3 && handCount < 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    int rand = Random.Range(0, cards.Count);
                    GameObject playerCard = Instantiate(cards[rand], new Vector3(0, 0, 0), Quaternion.identity);
                    cards.Remove(cards[rand]);
                    playerCard.transform.SetParent(myHandArea.transform, false);
                    handCount++;
                }
            }
            else if(cards.Count <3 && handCount < 3)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    int rand = Random.Range(0, cards.Count);
                    GameObject playerCard = Instantiate(cards[rand], new Vector3(0, 0, 0), Quaternion.identity);
                    cards.Remove(cards[rand]);
                    playerCard.transform.SetParent(myHandArea.transform, false);
                    handCount++;
                }
            }
            Debug.Log("cards : " + cards.Count);
        }
        else if(cards.Count == 0)
        {
            Grave();
            Draw();
        }
        GetComponent<DrawCardContorller>().drawTime = Time.time;
        GetComponent<Button>().interactable = false;
    }

    public void Grave()
    {
        cards.Add(Card1); cards.Add(Card2); cards.Add(Card3); cards.Add(Card4); cards.Add(Card5);
        cards.Add(Card1); cards.Add(Card2); cards.Add(Card3); cards.Add(Card4); cards.Add(Card5);
    }
}
