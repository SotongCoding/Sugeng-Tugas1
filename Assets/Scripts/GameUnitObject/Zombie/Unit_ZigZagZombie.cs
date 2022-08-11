using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sugeng.TapZombie.GameUnit
{
    public class Unit_ZigZagZombie : Unit_BasicZombie
    {
        private void Awake()
        {
            moveLogic = new MoveBhv.MoveBhv_ZigZag(this);
        }
    }
}
