using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�÷��̾� ������ ����
    public float maxSpeed;
    public float jumpPower;
    public bool isJump;
    private Vector3 scale;

    //�÷��̾� ����
    private BoxCollider2D weaponCol;

    //�÷��̾� ������Ʈ
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    //�Ŵ���
    public SkillManager skillManager;
    public BtnManager btnManager;
    public Player_LifeBar Player_Life;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // ������ٵ� �ʱ�ȭ 
        sr = GetComponent<SpriteRenderer>(); // ��������Ʈ ������ �ʱ�ȭ
        animator = GetComponent<Animator>(); // �ִϸ����� �ʱ�ȭ
        weaponCol = GetComponentInChildren<BoxCollider2D>(); // �ڽ��ݶ��̴�
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
        // �÷��̾� ������ ����================================================
        if(Input.GetButtonUp("Horizontal")) // �¿� Ű���忡�� �� ���� // ���� �ڵ�
        {
            // rb.velocity.normalized.x �¿� ������ ���� ����
            rb.velocity = new Vector2(0.3f * rb.velocity.normalized.x, rb.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && isJump == false)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
        //=====================================================================

        //�÷��̾� ���� ���� ==================================================
        if(Input.GetKeyDown(KeyCode.J) 
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack1")) // �⺻����
        {
            animator.SetTrigger("Default_Attack");
        }
        if(Input.GetKeyDown(KeyCode.K)) // ��ų 1
        {
            skillManager.UseSkill(skillManager.Select[0]);
        }
        if(Input.GetKeyDown(KeyCode.L)) // ��ų 2
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
        float h = Input.GetAxisRaw("Horizontal"); // Ű���� �¿� �̵�
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse); // ���������� ���� �ѹ��� Ȯ ����
        if (rb.velocity.x > maxSpeed)  // ���������� �̵���, �ִ� �ӷ��� ���� ������
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y); // �ӷ��� max��

            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }

        else if(rb.velocity.x < maxSpeed * (-1)) // �������� �̵���
        {
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y); // y���� ������ �����̹Ƿ� 0���� �����ϸ� ��������
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
