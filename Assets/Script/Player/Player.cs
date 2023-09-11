using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //플레이어 움직임 제어
    public float maxSpeed;
    public float jumpPower;
    public bool isJump;
    private Vector3 scale;

    //플레이어 공격
    private BoxCollider2D weaponCol;

    //플레이어 컴포넌트
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    //매니저
    public SkillManager skillManager;
    public BtnManager btnManager;
    public Player_LifeBar Player_Life;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // 리지드바디 초기화 
        sr = GetComponent<SpriteRenderer>(); // 스프라이트 랜더러 초기화
        animator = GetComponent<Animator>(); // 애니메이터 초기화
        weaponCol = GetComponentInChildren<BoxCollider2D>(); // 박스콜라이더
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
    }

    void Start()
    {
        isJump = true;
        weaponCol.enabled = false;
        scale = transform.localScale;
    }

    void Update()
    {
        // 플레이어 움직임 관련================================================
        if(Input.GetButtonUp("Horizontal")) // 좌우 키보드에서 손 땔때 // 멈춤 코드
        {
            // rb.velocity.normalized.x 좌우 구분을 위해 넣음
            rb.velocity = new Vector2(0.3f * rb.velocity.normalized.x, rb.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && isJump == false)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
        //=====================================================================

        //플레이어 공격 관련 ==================================================
        if(Input.GetKeyDown(KeyCode.J) 
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack1")) // 기본공격
        {
            animator.SetTrigger("Default_Attack");
        }
        if(Input.GetKeyDown(KeyCode.K)) // 스킬 1
        {
            skillManager.UseSkill(skillManager.Select[0]);
        }
        if(Input.GetKeyDown(KeyCode.L)) // 스킬 2
        {
            skillManager.UseSkill(skillManager.Select[1]);
        }
        //=====================================================================
        if(Input.GetKeyDown (KeyCode.Y))
        {
            btnManager.ActivePanel();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Player_Life.SetHp(10);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // 키보드 좌우 이동
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse); // 오른쪽으로 힘을 한번에 확 가함
        if (rb.velocity.x > maxSpeed)  // 오른쪽으로 이동함, 최대 속력을 만약 넘으면
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y); // 속력을 max로

            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }

        else if(rb.velocity.x < maxSpeed * (-1)) // 왼쪽으로 이동함
        {
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y); // y값은 점프의 영향이므로 0으로 제한하면 점프안함
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJump = false;
        }
    }
}
