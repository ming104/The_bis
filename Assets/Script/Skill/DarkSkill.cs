using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class DarkSkill : MonoBehaviour
{
    [SerializeField] GameObject DarkSkillGO;
    [SerializeField] BoxCollider2D DarkSkill_Col;

    public void Awake()
    {
        DarkSkill_Col = DarkSkillGO.GetComponent<BoxCollider2D>();
        DarkSkill_Col.enabled = false;
    }

    void Start()
    {
        StartCoroutine(DarkSkillUse());
    }

    public IEnumerator DarkSkillUse()
    {
        yield return new WaitForSeconds(4f);
        DarkSkill_Col.enabled = true;
        yield return new WaitForSeconds(0.1f);
        DarkSkill_Col.enabled = false;
    }
}
