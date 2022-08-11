using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sugeng.TapZombie.GameUnit.MoveBhv
{
    public interface IBaseMovementBehaviour
    {
        BaseUnit unit { get; }
        public void Move();
    }
}
