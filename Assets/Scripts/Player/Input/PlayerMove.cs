using Player.Interfaces;
using UnityEngine;
using VehicleBehaviour;
using Zenject;

namespace Player.Input
{
    public class PlayerMove : ITickable
    {
        private WheelVehicle _vehicleControl;
        private Vector2 _moveDirection;
        private IMovePlayerInput _playerInput;

        public PlayerMove(IMovePlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        public void SetVehicle(WheelVehicle vehicle)
        {
            _vehicleControl = vehicle;
        }

        public void Tick()
        {
            if (_vehicleControl != null)
            {
                _vehicleControl.horizontalInput = _playerInput.GetDirection().x;
                _vehicleControl.verticalInput = _playerInput.GetDirection().y;
            }
        }
    }
}