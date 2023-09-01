using UnityEngine;

public enum Skill
{
    Water_Skill, // �ֺ� ���� ������ �踮��
    Light_Skill, // �̼� ����
    Dark_Skill, // ���� �� ���ݷ�, �̼� ����
    Fire_Skill, // �ٶ󺸴� ���⿡ ȭ������
    Dirt_Skill, // ���Ÿ� ���� 1ȸ ���
    Tree_Skill, // ��ȸ��
    Lightning_Skill, // ��Ÿ ��ȭ
    Wind_Skill, // ����
    SkillNULL
}
public enum Skill_Property
{
    Water, // �ֺ� ���� ������ �踮��
    Light, // �̼� ����
    Dark, // ���� �� ���ݷ�, �̼� ����
    Fire, // �ٶ󺸴� ���⿡ ȭ������
    Dirt, // ���Ÿ� ���� 1ȸ ���
    Tree, // ��ȸ��                      
    Lightning, // ��Ÿ ��ȭ
    Wind // ����
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

    public void UseSkill(Skill useSkill) // ��ų ����
    {
        switch (useSkill)
        {
            case Skill.Water_Skill:
                Debug.Log("��");
                break;
            case Skill.Light_Skill:
                Debug.Log("��");
                break;
            case Skill.Dark_Skill:
                Debug.Log("���");
                break;
            case Skill.Fire_Skill:
                Debug.Log("��");
                break;
            case Skill.Dirt_Skill:
                Debug.Log("��");
                break;
            case Skill.Tree_Skill:
                Debug.Log("����");
                break;
            case Skill.Lightning_Skill:
                Debug.Log("����");
                break;
            case Skill.Wind_Skill:
                Debug.Log("�ٶ�");
                break;
        }

    }



    //public Skill GetSkill_Second()
    //{
    //    return Select[1];
    //}
}
