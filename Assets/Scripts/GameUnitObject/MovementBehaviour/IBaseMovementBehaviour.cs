using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseMovementBehaviour
{
    BaseUnit unit { get;}
    public void Move();
}
