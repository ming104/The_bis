using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSkill : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    public GameObject[] bubble;

    int objSize;
    float circleR = 1.5f;
    float deg;
    float objSpeed = 500f;

    private void Start()
    {
        objSize = bubble.Length;
        target = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = target.transform.position;
        deg += Time.deltaTime * objSpeed;
        if (deg < 360)
        {
            for (int i = 0; i < objSize; i++)
            {
                var rad = Mathf.Deg2Rad * (deg + (i * (360 / objSize)));
                var x = circleR * Mathf.Sin(rad);
                var y = circleR * Mathf.Cos(rad);
                bubble[i].transform.position = transform.position + new Vector3(x, y);
                bubble[i].transform.rotation = Quaternion.Euler(0, 0, (deg + (i * (360 / objSize))) * -1);
            }

        }
        else
        {
            deg = 0;
        }
    }
}
