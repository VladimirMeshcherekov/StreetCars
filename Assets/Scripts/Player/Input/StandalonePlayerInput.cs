using UnityEngine;

namespace Player.Input
{
    public class StandalonePlayerInput
    {
        private readonly EventBus _eventBus;
        
        public StandalonePlayerInput(EventBus eventBus)
        {
            _eventBus = eventBus;
            var standaloneInput = new PlayerStandaloneInput();
            standaloneInput.Enable();
            standaloneInput.Player.PlayerMoveDirection.performed += ctx => SetPlayerDirection(standaloneInput.Player.PlayerMoveDirection.ReadValue<Vector2>());
        }

        private void SetPlayerDirection(Vector2 moveDirection)
        {
            _eventBus.Invoke(new PlayerInputChangedSignal(moveDirection));
        }
    }
}
