using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public GameObject player;

    public enum EnemyState
    {
        Idle = 0,
        Move = 1,
        Attack = 2,
        Damage = 3,
        Die = 4
    };
    EnemyState m_State = EnemyState.Idle;


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
            case EnemyState.Damage:
                Damage();
                    break;
            case EnemyState.Die:
                Die();
                    break;       
        }
       
    }

    void Idle()
    {
        
    }

    void Move()
    {

    }

    void Attack()
    {

    }

    void Damage()
    {

    }

    void Die()
    {

    }
}
