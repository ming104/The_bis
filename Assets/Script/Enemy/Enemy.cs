using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int attackCount;
    public BtnManager btnmanager;
    
    // Start is called before the first frame update
    void Start()
    {
        btnmanager = GameObject.Find("BtnManager").GetComponent<BtnManager>();
        attackCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("공격 당함");
        attackCount++;
    }
}
