using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sugeng.TapZombie.GameUnit
{
    public abstract class BaseUnit : MonoBehaviour, Utils.Ray2D.IRayObject
    {
        //Event
        public System.Action OnUnitDie;
        public System.Action OnUnitReachEndLine;

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

        public abstract void Initial();
        //When Player Click it
        void Utils.Ray2D.IRayObject.OnHitRayEvent()
        {
            OnUnitDie?.Invoke();
            gameObject.SetActive(false);
        }
        //When unit reach endLine
        void CheckEndLine()
        {
            if (transform.position.y <= deathPosY && gameObject.activeSelf)
            {
                OnUnitReachEndLine?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}