using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRayRotate : MonoBehaviour
{
   
   public GameObject player;
   public GameObject Ray;
    void Update()
    {
        if(player.GetComponent<MoveController>().holdingTorch){
            Vector2 dist = player.transform.position - Ray.transform.position;
            dist.Normalize();
            float rotZ = Mathf.Atan2(dist.x,dist.y)*Mathf.Rad2Deg;
            Ray.transform.rotation = Quaternion.Euler(0f, 0f, -rotZ-90);
        }

    }
}
