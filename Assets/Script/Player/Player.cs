using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player Move Control
    public float maxSpeed;
    public float jumpPower;
    public bool isJump;
    private Vector3 scale;

    //PlayerAttack
    private BoxCollider2D weaponCol;

    //Player Component
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    //managers
    public SkillManager skillManager;
    public BtnManager btnManager;
    public Player_LifeBar Player_Life;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigid Reset
        sr = GetComponent<SpriteRenderer>(); // SpriteRenderer Reset
        animator = GetComponent<Animator>(); // Animator reset
        weaponCol = GetComponentInChildren<BoxCollider2D>(); // BoxCollider2D reset
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>(); // Find SkillManager to reset
    }

    void Start()
    {
        isJump = true;
        weaponCol.enabled = false;
        scale = transform.localScale;
    }

    void Update()
    {
        // PlayerMove ================================================
        if(Input.GetButtonUp("Horizontal")) // 키보드에서 손 땔때 // 멈춤 코드
        {
            // rb.velocity.normalized.x  //좌우 구분을 위해 넣음
            rb.velocity = new Vector2(0.3f * rb.velocity.normalized.x, rb.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && isJump == false)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
        //=====================================================================

        //PlayerAttack ==================================================
        if(Input.GetKeyDown(KeyCode.J) 
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack1")) // DefaultAttack
        {
            animator.SetTrigger("Default_Attack");
        }
        if(Input.GetKeyDown(KeyCode.K)) // skill 1
        {
            skillManager.UseSkill(skillManager.Select[0]);
        }
        if(Input.GetKeyDown(KeyCode.L)) // skill 2
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
        float h = Input.GetAxisRaw("Horizontal"); // Keyboard Horizontal
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse); // Right -> AddForce
        if (rb.velocity.x > maxSpeed)  // 오른쪽으로 이동함, 만약 최대 속력을 넘으면
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y); // 속력을 Max만큼으로 바꿈

            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }

        else if(rb.velocity.x < maxSpeed * (-1)) // 왼쪽으로 이동
        {
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y); // y값은 점프의 영향이므로 0으로 제한시 점프를 하지 않음
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
        if(collision.gameObject.CompareTag("Enemy_Attack_Collider"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log(enemy.GetDamage());
            Player_Life.SetHp(enemy.GetDamage());
        }
    }
}
