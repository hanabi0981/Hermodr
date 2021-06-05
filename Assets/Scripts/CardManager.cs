using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Inst { get; private set; }
    private void Awake() => Inst = this;

    [SerializeField] ItemSO itemSO;
    [SerializeField] GameObject cardPrefabs;
    [SerializeField] List<Card> myCards;
    [SerializeField] Transform cardSpawnPoint;
    [SerializeField] Transform myCardsLeft;
    [SerializeField] Transform myCardsRight;

    List<Item> itemBuffer;

    public Item PopItem()
    {
        if (itemBuffer.Count == 0)
            SetupItemBuffer();

        Item item = itemBuffer[0];
        itemBuffer.RemoveAt(0);
        return item;
    }

    void SetupItemBuffer()
    {
        itemBuffer = new List<Item>();
        for(int i = 0; i<itemSO.items.Length; i++)
        {
            Item item = itemSO.items[i];
            for (int j = 0; j < item.percent; j++)
            {
                itemBuffer.Add(item);
            }
        }

        for(int i=0; i <itemBuffer.Count; i++)
        {
            int rand = Random.Range(i, itemBuffer.Count);
            Item temp = itemBuffer[i];
            itemBuffer[i] = itemBuffer[rand];
            itemBuffer[rand] = temp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupItemBuffer();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            AddCard();
            
    }

    void AddCard()
    {
        var cardObject = Instantiate(cardPrefabs, cardSpawnPoint.position, Utils.QI);
        var card = cardObject.GetComponent<Card>();
        card.Setup(PopItem(),true);
        myCards.Add(card);

        CardAlignment();
    }

    void SetOriginOrder()
    {
        int count = myCards.Count;
        for (int i = 0; i<count; i++)
        {
            var targetCard = myCards[i];
            targetCard?.GetComponent<Order>().SetOriginOrder(i);
        }
    }

    void CardAlignment()
    {
        List<PRS> originCardPRSs = new List<PRS>();
        originCardPRSs = LineAlignment(myCardsLeft, myCardsRight, myCards.Count, Vector2.one);

        var targetCards = myCards;
        for(int i = 0; i<targetCards.Count; i++)
        {
            var targetCard = targetCards[i];

            targetCard.originPRS = originCardPRSs[i];
            targetCard.MoveTransform(targetCard.originPRS, true, 0.7f);
        }
    }

    List<PRS> LineAlignment(Transform leftTr, Transform rightTr, int objCount, Vector2 scale)
    {
        float[] objLerps = new float[objCount];
        List<PRS> results = new List<PRS>(objCount);

        switch (objCount)
        {
            case 1: objLerps = new float[] { 0 }; break;
            case 2: objLerps = new float[] { 0, 0.25f }; break;
            case 3: objLerps = new float[] { 0, 0.25f, 0.5f }; break;
            case 4: objLerps = new float[] { 0, 0.25f, 0.5f, 0.75f }; break;
            case 5: objLerps = new float[] { 0, 0.25f, 0.5f, 0.75f, 1 }; break;
            default: break;
        }

        for(int i = 0; i<objCount; i++)
        {
            var targetPos = Vector2.Lerp(leftTr.position, rightTr.position, objLerps[i]);
            var targetRot = Utils.QI;

            results.Add(new PRS(targetPos, targetRot, scale));
        }

        return results;
    }
}
