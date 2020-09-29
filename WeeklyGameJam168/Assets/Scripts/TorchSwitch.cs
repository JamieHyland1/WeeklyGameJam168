using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSwitch : MonoBehaviour
{
    public GameObject torch;

    public Transform getTorchParent(){
        return torch.transform.parent;
    }

    public void torchPickup(GameObject g){
       torch.transform.position =  g.transform.position + new Vector3(.2f, .2f, 0f);
       torch.transform.parent = g.transform;
    }
   public void SwitchTorchParent(GameObject one, GameObject two, Vector3 torchOffset){
       if(torch.transform.parent == one.transform){
           torch.transform.position = two.transform.position + torchOffset;
           torch.transform.parent = null;
           torch.transform.parent = two.transform;
       }else if(torch.transform.parent == two.transform){
           torch.transform.position = one.transform.position + torchOffset;
           torch.transform.parent = null;
           torch.transform.parent = one.transform;
       }
   }
}
