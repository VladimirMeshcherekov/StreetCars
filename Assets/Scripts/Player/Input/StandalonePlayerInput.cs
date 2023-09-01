using Player.Interfaces;
using UnityEngine;

namespace Player.Input
{
    public class StandalonePlayerInput : IMovePlayerInput
    {
        private Vector2 _moveDirection;

        public StandalonePlayerInput()
        {
            var standaloneInput = new PlayerStandaloneInput();
            standaloneInput.Enable();
            standaloneInput.Player.PlayerMoveDirection.performed += ctx => SetPlayerDirection(standaloneInput.Player.PlayerMoveDirection.ReadValue<Vector2>());
        }

        private void SetPlayerDirection(Vector2 moveDirection)
        {
            _moveDirection = moveDirection;
        }

        public Vector2 GetDirection()
        {
            return _moveDirection;
        }
    }
}