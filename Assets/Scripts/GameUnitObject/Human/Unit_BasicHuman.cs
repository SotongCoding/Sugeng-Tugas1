using System.Collections;
using System.Collections.Generic;
using Sugeng.TapZombie.GameUnit.MoveBhv;
using UnityEngine;

namespace Sugeng.TapZombie.GameUnit
{
    public class Unit_BasicHuman : BaseUnit
    {
        protected override IBaseMovementBehaviour MoveLogic
        {
            get
            {
                if (moveLogic == null) { moveLogic = new MoveBhv.MoveBhv_StarightDown(this); }
                return moveLogic;
            }
        }
        protected override void ReachEndLine()
        {
            if (gameObject.activeSelf)
            {
                GameManager.Instance.GainScore();
                GameManager.Instance.AddSurvivedUnit();
                GameManager.Instance.unitSpawn++;
            }

        }

        protected override void UnitDeath()
        {
            GameManager.Instance.GameOver();
        }
    }
}
