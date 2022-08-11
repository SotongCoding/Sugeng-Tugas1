using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_BasicHuman : BaseUnit
{

    private void Awake()
    {
        moveLogic = new MoveBhv_StarightDown(this);
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
