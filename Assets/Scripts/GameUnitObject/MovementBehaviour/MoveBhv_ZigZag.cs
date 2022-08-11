using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBhv_ZigZag : IBaseMovementBehaviour
{
    float horizontalValue = 0;
    float minArea = -2.03f,
    maxArea = 2.03f;
    public BaseUnit unit { private set; get; }

    float currentTimer;
    float changeDirTimer;
    public MoveBhv_ZigZag(BaseUnit untiImplement)
    {
        unit = untiImplement;
    }

    public virtual void Move()
    {
        unit.transform.Translate(unit.speed * 0.7f
        * Time.deltaTime * (new Vector2(horizontalValue, -1)));

        currentTimer += Time.deltaTime;
        if (currentTimer >= changeDirTimer)
        {
            horizontalValue = Random.Range(0, 2) > 1 ? 1 : -1;
            currentTimer = 0;
            changeDirTimer = Random.Range(1f, 1.5f);
        }

        if (unit.transform.position.x < minArea || unit.transform.position.x > maxArea) { horizontalValue *= -1; }

    }
}
