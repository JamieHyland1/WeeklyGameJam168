using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTorches : MonoBehaviour
{
    public GameObject torch1;
    public GameObject torch2;

    public bool BothTorchesLit(){
        return torch1.GetComponent<Torch>().torchLit && torch2.GetComponent<Torch>().torchLit; 
    }
}
