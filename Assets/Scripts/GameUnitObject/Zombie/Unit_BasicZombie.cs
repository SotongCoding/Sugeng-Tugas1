using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sugeng.TapZombie.GameUnit
{
    public class Unit_BasicZombie : BaseUnit
    {
        private void Awake()
        {
            Initial();
        }
        public override void Initial()
        {
            base.OnUnitDie += GameManager.Instance.GainScore;
            base.OnUnitDie += GameManager.Instance.AddUnitKilled;
            base.OnUnitDie += () => { GameManager.Instance.unitSpawn++; };

            base.OnUnitReachEndLine += () => { GameManager.Instance.ReduceHealth(); };
            base.OnUnitReachEndLine += () => { GameManager.Instance.unitSpawn++; };
        }
    }
}
