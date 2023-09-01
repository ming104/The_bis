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

    private void Start()
    {
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
                Debug.Log("물");
                break;
            case Skill.Light_Skill:
                Debug.Log("빛");
                break;
            case Skill.Dark_Skill:
                Debug.Log("어둠");
                break;
            case Skill.Fire_Skill:
                Debug.Log("불");
                break;
            case Skill.Dirt_Skill:
                Debug.Log("흙");
                break;
            case Skill.Tree_Skill:
                Debug.Log("나무");
                break;
            case Skill.Lightning_Skill:
                Debug.Log("번개");
                break;
            case Skill.Wind_Skill:
                Debug.Log("바람");
                break;
        }

    }



    //public Skill GetSkill_Second()
    //{
    //    return Select[1];
    //}
}
