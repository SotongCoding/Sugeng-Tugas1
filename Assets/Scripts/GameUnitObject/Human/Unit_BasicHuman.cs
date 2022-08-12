using System.Collections;
using System.Collections.Generic;
using Sugeng.TapZombie.GameUnit.MoveBhv;
using UnityEngine;

namespace Sugeng.TapZombie.GameUnit
{
    public class Unit_BasicHuman : BaseUnit
    {
        private void Awake() {
            Initial();
        }
        public override void Initial()
        {
            base.OnUnitReachEndLine += GameManager.Instance.GainScore;
            base.OnUnitReachEndLine += GameManager.Instance.AddSurvivedUnit;
            base.OnUnitReachEndLine += () => { GameManager.Instance.unitSpawn++; };

            base.OnUnitDie += GameManager.Instance.GameOver;
        }
    }
}
