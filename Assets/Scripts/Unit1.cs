using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit1 : MonoBehaviour
{
    unitState u_State;
    Animator anim;
    Transform monster, boss;

    public float moveSpeed = 2f;   // 이동속도
    public float attackPower = 20f;   // 공격력
    public float hp = 100f;   // 체력
    public float maxHp = 100f;   // 최대 체력

    float currentTime = 0;   // 누적 시간
    float attackDelay = 2f;   // 공격 딜레이 시간
  
    bool attack_go;  

    enum unitState   // 상태 상수
    {
        Move, Attack, Damaged, Die
    }

    // Start is called before the first frame update
    void Start()
    {
        u_State = unitState.Move;   // 시작할 때 상태 (움직임)
       
        // boss = GameObject.Find("Boss").transform;
       // anim = transform.GetComponent<Animator>();   // 애니메이터를 가져온다.
      
        attack_go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (null != GameObject.FindGameObjectWithTag("Monster"))
        {
            anim = transform.GetComponent<Animator>();   // 애니메이터를 가져온다.
            monster = GameObject.FindGameObjectWithTag("Monster").transform;
        }

        switch (u_State)
        {
            case unitState.Attack: Attack(); break;
            case unitState.Move: Move(); break;
            case unitState.Die: Die(); break;
        }      
    }

    void OnTriggerStay2D(Collider2D collision)   // 몬스터와 충돌이 일어날 때..
    {
        if (collision.CompareTag("Monster"))
        {
            anim.SetTrigger("MoveToAttackDelay");   // 애니메이션 상태 변환 (달리기 -> 공격준비)
            u_State = unitState.Attack;   // 공격 애니메이션 전환
            attack_go = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            attack_go = true;
            // anim.SetTrigger("AttackToMove");
          //  u_State = unitState.Move;
        }
    }

    void Move()
    {
        if (attack_go == true)
        {
            anim.SetTrigger("AttackToMove");
        }

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);   // 오른쪽으로 이동.
    }

    void Attack()
    {
       // moveSpeed = 0;   // 공격 중일 때 스피드 값 0 으로 움직임 멈추기
        currentTime += Time.deltaTime;   // 쿨타임 축적

        if (currentTime > attackDelay)   // 2초에 한 번씩 공격
        {
            print("유닛이 공격");
            anim.SetTrigger("StartAttack");   // 애니메이션 상태 변환 (달리기 -> 공격)
            monster.GetComponent<Monster1>().DamageAction(attackPower);   // 몬스터 Monster1 의 DamageAction 에 접근
           // boss.GetComponent<Boss1>().DamageAction(attackPower);   // 보스 Boss1 의 DamageAction 에 접근
            currentTime = 0;   // 축적한 쿨타임 초기화
        }

        if (attack_go == true)   // 만약 유닛 체력이 0 이하면..
        {
            // attack_go = false;
            //   anim.SetTrigger("AttackToMove");
            u_State = unitState.Move;   // Move 로 상태 변환
        }
    }

    void Die()
    {
        anim.SetTrigger("Die");   // 애니메이션 상태 변환 (죽음)
    }

    public void DamageAction(float damage)
    {
        hp -= damage;   // 유닛의 체력에 몬스터의 공격력을 뺀다.
        print("유닛 남은체력 : " + hp);

        if (hp <= 0)
        {
            u_State = unitState.Die;   // 피가 0 이하면 Die 로 상태 변환
            Destroy(gameObject);   // 체력이 0 이되면 사라짐.
            print("유닛이 죽음");
        }
    }
}
