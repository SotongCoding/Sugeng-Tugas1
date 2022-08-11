using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_ZigZagZombie : Unit_BasicZombie
{
  private void Awake() {
    moveLogic =  new MoveBhv_ZigZag(this);
  }
}
