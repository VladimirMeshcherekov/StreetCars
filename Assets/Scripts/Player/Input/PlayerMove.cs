using UnityEngine;
using VehicleBehaviour;

namespace Player.Input
{
    public class PlayerMove
    {
        private readonly WheelVehicle _vehicleControl;
        private Vector2 _moveDirection;

        public PlayerMove(WheelVehicle vehicleControl, EventBus eventBus)
        {
            _vehicleControl = vehicleControl;
            eventBus.Subscribe<PlayerInputChangedSignal>(PlayerDirectionChanged, 0);
        }

        private void PlayerDirectionChanged(PlayerInputChangedSignal value)
        {
            _vehicleControl.horizontalInput = value.Value.x;
            _vehicleControl.verticalInput = value.Value.y;
        }
    }
}