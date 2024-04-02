using System.Collections;
using UnityEngine;

public enum Skill
{
    Water_Skill, // 주변 적을 때리는 배리어
    Light_Skill, // 이속 증가
    Dark_Skill, // 주위 적 공격력, 이속 감소
    Fire_Skill, // 바라보는 방향에 화염피해
    Dirt_Skill, // 원거리 공격 1회 방어
    Tree_Skill, // 피회복
    Lightning_Skill, // 평타 강화
    Wind_Skill, // 점멸
    SkillNULL
}
public enum Skill_Property
{
    Water, // 주변 적을 때리는 배리어
    Light, // 이속 증가
    Dark, // 주위 적 공격력, 이속 감소
    Fire, // 바라보는 방향에 화염피해
    Dirt, // 원거리 공격 1회 방어
    Tree, // 피회복                      
    Lightning, // 평타 강화
    Wind // 점멸
}

public class SkillManager : MonoBehaviour
{
    public Skill[] Select;  
    public GameObject[] skillPrefab;
    public GameObject Sword;
    public GameObject player;
    public Player_LifeBar life;

    public DrawRay_Wind isWS;

    public bool iswallAtiving;

    private bool canDash;
    [HideInInspector]
    public bool isDashing;
    [SerializeField]
    private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    private void Start()
    {
        canDash = true;
        iswallAtiving = false;
        Select[0] = Skill.SkillNULL;
        Select[1] = Skill.SkillNULL;

    }


    public Skill SetSkill(Skill_Property property)
    {
            return property switch
            {
                Skill_Property.Water => Skill.Water_Skill,
                Skill_Property.Light => Skill.Light_Skill,
                Skill_Property.Dark => Skill.Dark_Skill,
                Skill_Property.Fire => Skill.Fire_Skill,
                Skill_Property.Dirt => Skill.Dirt_Skill,
                Skill_Property.Tree => Skill.Tree_Skill,
                Skill_Property.Lightning => Skill.Lightning_Skill,
                Skill_Property.Wind => Skill.Wind_Skill,
                _ => Skill.SkillNULL // default
            };
    }

    public void UseSkill(Skill useSkill) // 스킬 사용시
    {
        switch (useSkill)
        {
            case Skill.Water_Skill:
                GameObject Water = Instantiate(skillPrefab[0]);
                Destroy(Water, 20);

                break;
            case Skill.Light_Skill:
                GameObject Light = Instantiate(skillPrefab[1]);
                Destroy(Light, 10);
                break;
            case Skill.Dark_Skill:
                GameObject Dark = Instantiate(skillPrefab[2]);
                Dark.transform.SetParent(player.transform, false);
                Destroy(Dark, 10);
                break;
            case Skill.Fire_Skill:
                GameObject Fire = Instantiate(skillPrefab[3]);
                Fire.transform.localEulerAngles = new Vector3(0, 90 * player.transform.localScale.x,0);
                Fire.transform.position = player.transform.position;
                
                break;
            case Skill.Dirt_Skill:
                if (!iswallAtiving) // is disabled
                {
                    GameObject Dirt_Wall = Instantiate(skillPrefab[4]) as GameObject;
                    Dirt_Wall.transform.position = new Vector3(player.transform.position.x + 3f * player.transform.localScale.x, player.transform.position.y, 0f);
                    iswallAtiving = true;
                }
                else
                {
                    iswallAtiving = false;
                    Destroy(GameObject.FindGameObjectWithTag("Dirt_Wall"));
                }
                break;
            case Skill.Tree_Skill:
                GameObject Tree = Instantiate(skillPrefab[5]) as GameObject;
                Tree.transform.SetParent(player.transform, false);
                life.TreeSkill();
                break;
            case Skill.Lightning_Skill:
                GameObject Lightning = Instantiate(skillPrefab[6])as GameObject;
                Lightning.transform.SetParent(Sword.transform, false);
                Destroy(Lightning, 30);
                break;
            case Skill.Wind_Skill:
                if (canDash == true && isWS.isWindSkill(player.transform.localScale.x) == true )
                {
                    StartCoroutine(WindSkill());
                }
                break;
        }

    }

    private IEnumerator WindSkill()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.transform.Translate(Vector2.right * dashingPower * player.transform.localScale.x);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        player.GetComponent<Rigidbody2D>().gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
