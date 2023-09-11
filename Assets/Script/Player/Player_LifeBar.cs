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
    void Start()
    {
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
}
