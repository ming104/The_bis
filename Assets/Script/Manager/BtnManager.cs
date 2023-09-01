using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public SkillManager sm;
    public GameObject selectPanel;
    private int skill_Index;

    [SerializeField]
    private GameObject[] Skill_Btn;
    /*
    Water       0
    Light       1
    Dark        2
    Fire        3
    Dirt        4
    Tree        5
    Lightning   6
    Wind        7
    */

    void Start()
    {
        sm = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        selectPanel.SetActive(false);
    }

    public void ActivePanel()
    {
        selectPanel.SetActive(true);
    }

    public void Btn(int num)
    {
        switch (num)
        {
            case 0 :
                sm.Select[skill_Index] = sm.SetSkill(Skill_Property.Water);
                break;
            case 1:
                sm.Select[skill_Index] = sm.SetSkill(Skill_Property.Light); 
                break;
            case 2:
                sm.Select[skill_Index] = sm.SetSkill(Skill_Property.Dark);
                break;
            case 3:
                sm.Select[skill_Index] = sm.SetSkill(Skill_Property.Fire);
                break;
            case 4:
                sm.Select[skill_Index] = sm.SetSkill(Skill_Property.Dirt);
                break;
            case 5:
                sm.Select[skill_Index] = sm.SetSkill(Skill_Property.Tree);
                break;
            case 6:
                sm.Select[skill_Index] = sm.SetSkill(Skill_Property.Lightning);
                break;
            case 7:
                sm.Select[skill_Index] = sm.SetSkill(Skill_Property.Wind);
                break;
        }
        skill_Index++;
        selectPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
