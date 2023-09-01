using Player.Interfaces;
using SimpleInputNamespace;
using UnityEngine;

namespace Player.Input
{
    public class JoystickPlayerInput : IMovePlayerInput
    {
        private Joystick _joystick;
        private Vector2 _moveDirection;

        public JoystickPlayerInput(Joystick joystick)
        {
            _joystick = joystick;
        }


        public Vector2 GetDirection()
        {
            return _joystick.Value;
        }
    }
}