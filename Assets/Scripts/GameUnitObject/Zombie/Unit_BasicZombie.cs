using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_BasicZombie : BaseUnit
{
    private void Awake()
    {
        moveLogic = new MoveBhv_StarightDown(this);
    }
    protected override void ReachEndLine()
    {
        if (gameObject.activeSelf)
        {
            GameManager.Instance.ReduceHealth();
            GameManager.Instance.unitSpawn++;
        }


    }

    protected override void UnitDeath()
    {
        GameManager.Instance.GainScore();
        GameManager.Instance.AddUnitKilled();
        GameManager.Instance.unitSpawn++;
    }
}
