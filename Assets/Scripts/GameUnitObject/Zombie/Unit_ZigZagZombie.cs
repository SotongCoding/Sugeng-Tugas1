using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sugeng.TapZombie.GameUnit
{
    public class Unit_ZigZagZombie : Unit_BasicZombie
    {
        protected override MoveBhv.IBaseMovementBehaviour MoveLogic
        {
            get
            {
                if (moveLogic == null) { moveLogic = new MoveBhv.MoveBhv_ZigZag(this); }
                return moveLogic;
            }
        }
    }
}
