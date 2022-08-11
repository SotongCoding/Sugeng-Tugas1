using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBhv_StarightDown : IBaseMovementBehaviour
{
    public BaseUnit unit { private set; get; }

    public MoveBhv_StarightDown(BaseUnit untiImplement)
    {
        unit = untiImplement;
    }

    public virtual void Move()
    {
        unit.transform.Translate(unit.speed * Time.deltaTime * Vector2.down);
    }
}
