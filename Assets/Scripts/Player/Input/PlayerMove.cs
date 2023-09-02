using Player.Interfaces;
using Player.Pause.Interfaces;
using UnityEngine;
using VehicleBehaviour;
using Zenject;

namespace Player.Input
{
    public class PlayerMove : ITickable, ICustomPauseBehavior
    {
        private WheelVehicle _vehicleControl;
        private Vector2 _moveDirection;
        private IMovePlayerInput _playerInput;
        private bool _isPaused = false;

        public PlayerMove(IMovePlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        public void Setup(WheelVehicle vehicle, IPauseHandler pauseHandler)
        {
            _vehicleControl = vehicle;
            pauseHandler.AddPausedBehaviorObject(this);
        }

        public void Tick()
        {
            if (_isPaused)
            {
                return;
            }

            if (_vehicleControl == null)
            {
                return;
            }

            _vehicleControl.horizontalInput = _playerInput.GetDirection().x;
            _vehicleControl.verticalInput = _playerInput.GetDirection().y;
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}