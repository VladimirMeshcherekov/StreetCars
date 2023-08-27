using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using VehicleBehaviour;

namespace Player.Input
{
    public class PlayerMoveInput
    {
        private PlayerInput _input;
        private WheelVehicle _vehicleControl;

        public PlayerMoveInput(WheelVehicle vehicleControl)
        {
            _vehicleControl = vehicleControl;
            _input = new PlayerInput();
            _input.Enable();
            _input.Player.PlayerMoveDirection.performed +=
                ctx => SetPlayerDirection(_input.Player.PlayerMoveDirection.ReadValue<Vector2>());
        }

        private void SetPlayerDirection(Vector2 direction)
        {
            _vehicleControl.horizontalInput = direction.x;
            _vehicleControl.verticalInput = direction.y;
        }
    }
}