using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Skill : MonoBehaviour
{
    private SkillManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        Destroy(gameObject, 30f);
    }

    private void OnDestroy()
    {
        sm.iswallAtiving = false;
    }
}
