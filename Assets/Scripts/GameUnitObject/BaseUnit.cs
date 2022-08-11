using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sugeng.TapZombie.GameUnit
{
    public abstract class BaseUnit : MonoBehaviour, Utils.Ray2D.IRayObject
    {
        public System.Action OnUnitDie;
        public float speed { private set; get; } = 3;
        float originSpeed = 3;
        float deathPosY = -6.1f;

        protected  MoveBhv.IBaseMovementBehaviour moveLogic;

        private void Update()
        {
            CheckEndLine();
            Move();
        }

        private void OnEnable()
        {
            speed = originSpeed + (originSpeed * GameManager.Instance.speedMltiper);
            OnUnitDie += UnitDeath;
        }
        private void OnDisable()
        {
            OnUnitDie -= UnitDeath;
        }
        protected void Move()
        {
            moveLogic.Move();
        }

        protected abstract void UnitDeath();
        protected abstract void ReachEndLine();

        void Utils.Ray2D.IRayObject.OnHitRayEvent()
        {
            OnUnitDie?.Invoke();
            gameObject.SetActive(false);
        }
        void CheckEndLine()
        {
            if (transform.position.y <= deathPosY)
            {
                ReachEndLine();
                gameObject.SetActive(false);
            }
        }
    }
}