using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LightSkill : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private Player player;

    private void Start()
    {
        target = GameObject.Find("Player");
        player = target.GetComponent<Player>();
        player.maxSpeed = 10f;
        Invoke("MoveSpeed", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_pos = target.transform.position;
        transform.position = new Vector3(target_pos.x, target_pos.y - 0.7f, target_pos.z);
    }

    void MoveSpeed()
    {
        player.maxSpeed = 5f;
        Destroy(gameObject);
    }
}
