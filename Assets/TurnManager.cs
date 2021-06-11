using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class TurnManager : MonoBehaviour
{
	public static TurnManager Inst { get; private set; }
	void Awake() => Inst = this;

	[Header("Develop")]
	[SerializeField] [Tooltip("시작 턴 모드를 정합니다")] ETurnMode eTurnMode;
	[SerializeField] [Tooltip("카드 배분이 매우 빨라집니다")] bool fastMode;
	[SerializeField] [Tooltip("시작 카드 개수를 정합니다")] int startCardCount;


	[Header("Properties")]
	public bool isLoading; // 게임 끝나면 isLoading을 true로 하면 카드와 엔티티 클릭방지
	public bool myTurn;

	enum ETurnMode {My}
	WaitForSeconds delay05 = new WaitForSeconds(0.5f);

	public static Action<bool> OnAddCard;

	void GameSetup()
	{
//		if (fastMode)
//			delay05 = new WaitForSeconds(0.05f);

		switch (eTurnMode)
		{
			case ETurnMode.My:
				myTurn = true;
				break;
		}
	}

	public IEnumerator StartGameco()
    {
		GameSetup();

		for(int i=0;i<startCardCount; i++)
        {
			yield return delay05;
			OnAddCard?.Invoke(false);
			yield return delay05;
			OnAddCard?.Invoke(true);
		}
    }
}
