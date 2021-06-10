using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle1 : MonoBehaviour
{
    public float hp = 300f;   // 체력
    public float maxHp = 300f;   // 최대 체력

    Animator anim;
    Transform castle;

    castleState c_State;

    enum castleState   // 상태 상수
    {
        Damaged, Destroy   // 피격, 파괴
    }

    void Damaged()
    {
       // anim.SetTrigger("Damaged");   // 피격 애니메이션
    }
    void Destory()
    {
      // anim.SetTrigger("Destory");   // 파괴 애니메이션
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // anim = transform.GetComponent<Animator>();   // 애니메이터를 가져온다.

        switch (c_State)
        {
            case castleState.Damaged: Damaged(); break;
            case castleState.Destroy: Destory(); break;
        }
    }

    public void DamageAction(float damage)
    {
        hp -= damage;   // 성의 체력에 몬스터의 공격력을 뺀다.
        c_State = castleState.Damaged;
        print("성 남은체력 : " + hp);

        if (hp <= 0)
        {
            c_State = castleState.Destroy;   // 피가 0 이하면 Destory 로 상태 변환
            print("성이 파괴 됨 (게임 오버)");
            Time.timeScale = 0f;   // 게임 배속 -> 0배
        }
    }
}
