using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    // 550 0 -550

    void Start()
    {
        sm = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        selectPanel.SetActive(false);
        for(int i = 0; i < 8; i++) 
        {
            Skill_Btn[i].SetActive(false);
        }
    }

    public void ActivePanel()
    {
        for (int i = 0; i < 8; i++)
        {
            Skill_Btn[i].SetActive(false);
        }
        for (int i = 1; i < 4; i++)
        {
            int rand = Random.Range(0, 7);
            if (Skill_Btn[rand].activeSelf == true)
            {
                i--;
                //Debug.Log("중복감지!");
            }
            else
            {
                Skill_Btn[rand].SetActive(true);
                //Debug.Log(rand);
                switch (i)
                {
                    case 1:
                        Skill_Btn[rand].GetComponent<RectTransform>().anchoredPosition = new Vector3(550, 0, 0);
                        break;
                    case 2:
                        Skill_Btn[rand].GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                        break;
                    case 3:
                        Skill_Btn[rand].GetComponent<RectTransform>().anchoredPosition = new Vector3(-550, 0, 0);
                        break;
                    default:
                        Debug.LogError("변수 벗어남");
                        break;
                }
            } 
        }
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
