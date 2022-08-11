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

        protected MoveBhv.IBaseMovementBehaviour moveLogic;
        protected virtual MoveBhv.IBaseMovementBehaviour MoveLogic
        {
            get
            {
                if (moveLogic == null) { moveLogic = new MoveBhv.MoveBhv_StarightDown(this); }
                return moveLogic;
            }
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

        private void Update()
        {
            Move();
        }
        private void LateUpdate()
        {
            CheckEndLine();
        }

        protected void Move()
        {
            MoveLogic.Move();
        }

        protected abstract void UnitDeath();
        protected abstract void ReachEndLine();

        //When Player Click it
        void Utils.Ray2D.IRayObject.OnHitRayEvent()
        {
            OnUnitDie?.Invoke();
            gameObject.SetActive(false);
        }
        //When unit reach endLine
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