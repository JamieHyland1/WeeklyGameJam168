using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool torchLit = false;
  void LightTorch(){
      this.GetComponent<Animator>().SetTrigger("LightTorch");
      torchLit = true;
  }
}
