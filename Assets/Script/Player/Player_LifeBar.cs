using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.UI;

public class Player_LifeBar : MonoBehaviour
{
    [SerializeField]
    private Slider Life_Bar;

    float maxHp = 50f;
    float currentHp;

    // Start is called before the first frame update
    private void Awake()
    {
        Life_Bar.maxValue = maxHp;
        currentHp = maxHp;
    }


    // Update is called once per frame
    void Update()
    {
        Life_Bar.value = currentHp;
    }

    public float GetHP()
    {
        return currentHp;
    }

    public void SetHp(float hp)
    {
        currentHp -= hp;
    }

    public void TreeSkill()
    {
        StartCoroutine(Tree_Heal_Skill());
    }

    IEnumerator Tree_Heal_Skill()
    {
        for(int i = 0; i < 18; i++)
        {
            if(currentHp < maxHp)
            {
                yield return new WaitForSeconds(0.5f);
                currentHp++;
            }
        }
    }
}
