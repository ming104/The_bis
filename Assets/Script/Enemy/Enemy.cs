using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Enemy_Info enemyData;
    [SerializeField] private Animator enemyAnimator;

    public Enemy_Info Enemy_Info
    {
        set {enemyData = value;}
        get {return enemyData;}
    }

    [Header("플레이어")]
    private GameObject player;
    public Rigidbody2D rb;
    
    public enum EnemyState
    {
        Idle = 0,
        Move = 1,
        Attack = 2,
        Damaged = 3,
        Die = 4
    };
    EnemyState m_State = EnemyState.Idle;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public float GetDamage()
    {
        return Enemy_Info.Damage;
    }

    void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                    break;
            case EnemyState.Move:
                Move();
                    break;
            case EnemyState.Attack:
                Attack();
                    break;
            case EnemyState.Damaged:
                Damaged();
                    break;
            case EnemyState.Die:
                Die();
                    break;       
        }
       
    }

    void Idle()
    {
        enemyAnimator.SetBool("Moving", false);
        if(Vector2.Distance(player.transform.position, transform.position) < enemyData.SightRange)
        {
            m_State = EnemyState.Move;
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
        enemyAnimator.SetBool("Moving", true);
        if(Vector2.Distance(player.transform.position, transform.position) < enemyData.AttackRange)
        {
            m_State = EnemyState.Attack;
        }
        if(Vector2.Distance(player.transform.position, transform.position) > enemyData.SightRange)
        {
            m_State = EnemyState.Idle;
        }
    }

    void Attack()
    {    
        enemyAnimator.SetTrigger("Attack");
        if(Vector2.Distance(player.transform.position, transform.position) > enemyData.AttackRange)
        {
            m_State = EnemyState.Move;
        }

        print("Attack");
    }

    void Damaged()
    {
        enemyAnimator.SetTrigger("Damaged");
        m_State = EnemyState.Move;
    }

    void Die()
    {
        enemyAnimator.SetTrigger("Die");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerAttack")) 
        {
            Debug.Log("공격 당함");
            m_State = EnemyState.Damaged;
        }
        if(collision.gameObject.CompareTag("DarkSkill_tag"))
        {
            print("debuff");    
        } 
    }
}
