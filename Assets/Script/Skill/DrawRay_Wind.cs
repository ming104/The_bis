using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay_Wind : MonoBehaviour
{
    [SerializeField]
    private float rayDistance = 4f;
    RaycastHit2D hitInfo;
    public bool isWindSkill(float playerScale)
    {
       
        if (playerScale > 0)
        {
            Debug.DrawRay(transform.position, Vector3.right * rayDistance, Color.red);
            hitInfo = Physics2D.Raycast(transform.position, Vector3.right, rayDistance);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.left * rayDistance, Color.red);
            hitInfo = Physics2D.Raycast(transform.position, Vector3.left, rayDistance);
        }
        //Debug.Log(hitInfo.collider.name);
        if (hitInfo.collider == null)
        {
            return true;
        }
        else
        {
            if(hitInfo.collider.tag == "Ground" || hitInfo.collider.tag == "Dirt_Wall")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

