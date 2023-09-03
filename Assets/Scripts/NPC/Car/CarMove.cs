using DG.Tweening;
using Player.Input;
using Player.Interfaces;
using Player.Pause.Interfaces;
using UnityEngine;
using Zenject;

namespace NPC.Car
{
    public class CarMove : Vehicle, IDamagePlayer, ICustomPauseBehavior
    {
        [SerializeField] private float viewDistance;
        [SerializeField] private float speed;
        [SerializeField] private bool showViewRay;
        private bool _isAbleToMove = true;
        private Tween _moveVehicle;
        private bool _isPaused = false;

        [Inject]
        private void Construct(IPauseHandler pauseHandler)
        {
            pauseHandler.AddPausedBehaviorObject(this);
        }

        private void FixedUpdate()
        {
            _isAbleToMove = true;

            if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.right),
                    out var hit, viewDistance))
            {
                if (hit.collider.gameObject.TryGetComponent(out CarMove carMove) ||
                    hit.collider.gameObject.TryGetComponent(out Components.PlayerCollider player))
                {
                    _isAbleToMove = false;
                }
            }

            Move();
            DebugShowViewRay();
        }

        private void Move()
        {
            if (!_isAbleToMove)
            {
                return;
            }

            if (_isPaused)
            {
                return;
            }

            _moveVehicle = transform.DOMove(transform.position + transform.right, 1 / speed);
        }

        private void DebugShowViewRay()
        {
            if (showViewRay)
            {
                Debug.DrawRay(transform.position, new Vector3(viewDistance, 0, 0), Color.magenta, Time.deltaTime);
            }
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}