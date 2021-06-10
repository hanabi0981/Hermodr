using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    monsterState m_State;
    Animator anim;
    Transform unit;
    Transform castle;

    public float moveSpeed = 1.5f;   // 이동속도
    public float attackPower = 20f;   // 공격력
    public float hp = 100f;   // 체력
    public float maxHp = 100f;   // 최대 체력

    float currentTime = 0;   // 누적 시간
    float attackDelay = 3f;   // 공격 딜레이 시간

    bool attack_go;
    bool unit_attack;
    bool castle_attack; 

    enum monsterState   // 상태 상수
    {
        Move, Attack, Damaged, Die
    }

    // Start is called before the first frame update
    void Start()
    {
        m_State = monsterState.Move;   // 시작할 때 상태 (움직임)
        //anim = transform.GetComponent<Animator>();   // 애니메이터를 가져온다.
        attack_go = false;
        castle_attack = false;
        unit_attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (null != GameObject.FindGameObjectWithTag("Castle"))
        {
            anim = transform.GetComponent<Animator>();   // 애니메이터를 가져온다.
        }

        switch (m_State)
        {
            case monsterState.Attack: Attack(); break;
            case monsterState.Move: Move(); break;
            case monsterState.Die: Die(); break;
        }
    }
    void OnTriggerStay2D(Collider2D collision)   // 유닛과 충돌이 일어날 때..
    {
        if (collision.CompareTag("Unit"))
        {
            unit = GameObject.FindGameObjectWithTag("Unit").transform;
            anim.SetTrigger("MoveToAttackDelay");   // 애니메이션 상태 변환 (달리기 -> 공격준비)
            m_State = monsterState.Attack;    // 공격 애니메이션 전환
            attack_go = false;
            castle_attack = false;
            unit_attack = true;
        }
        if (collision.CompareTag("Castle"))
        {
            castle = GameObject.FindGameObjectWithTag("Castle").transform;
            anim.SetTrigger("MoveToAttackDelay");   // 애니메이션 상태 변환 (달리기 -> 공격준비)
            m_State = monsterState.Attack;    // 공격 애니메이션 전환
            attack_go = false;
            castle_attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            attack_go = true;
            unit_attack = false;
            // anim.SetTrigger("AttackToMove");
            // m_State = monsterState.Move;           
        }
    }
    void Move()
    {
        if (attack_go == true)
        {
           anim.SetTrigger("AttackToMove");
        }
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);   // 왼쪽으로 이동.
    }

    void Attack()
    {
       // moveSpeed = 0;   // 공격 중일 때 스피드 값 0 으로 움직임 멈추기
        currentTime += Time.deltaTime;   // 쿨타임 축적

        if (unit_attack == true && currentTime > attackDelay)   // 3초에 한 번씩 공격
        {
            print("몬스터가 공격");
            anim.SetTrigger("StartAttack");   // 애니메이션 상태 변환 (달리기 -> 공격)
            unit.GetComponent<Unit1>().DamageAction(attackPower);   // 유닛 Unit1 의 DamageAction 에 접근
            currentTime = 0;   // 축적한 쿨타임 초기화
        }

        if (attack_go == true)   // 만약 유닛 체력이 0 이하면..
        {
           // attack_go = false;
           // anim.SetTrigger("AttackToMove");
           m_State = monsterState.Move;   // Move 로 상태 변환
        }

        if (castle_attack == true && currentTime > attackDelay)
        {
            print("성 공격");
            anim.SetTrigger("StartAttack");   // 애니메이션 상태 변환 (달리기 -> 공격)
            castle.GetComponent<Castle1>().DamageAction(attackPower);   // 성 Castle1 의 DamageAction 에 접근
            currentTime = 0;   // 축적한 쿨타임 초기화
        }
    }

    void Die()
    {
        anim.SetTrigger("Die");   // 애니메이션 상태 변환 (죽음)
    }   

    public void DamageAction(float damage)
    {
        hp -= damage;   // 몬스터의 체력에 유닛의 공격력을 뺀다.
        print("몬스터 남은체력 : " + hp);

        if (hp <= 0)
        {
            m_State = monsterState.Die;   // 피가 0 이하면 Die 로 상태 변환
            Destroy(gameObject);   // 체력이 0 이되면 사라짐.
            print("몬스터가 죽음");
        }
    }
}
