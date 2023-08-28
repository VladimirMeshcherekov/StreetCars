using SimpleInputNamespace;
using UnityEngine;
using Zenject;

namespace Player.Input
{
    public class JoystickPlayerInput : ITickable
    {
        private EventBus _eventBus;
        private Joystick _joystick;
        
        public JoystickPlayerInput(EventBus eventBus, Joystick joystick)
        {
            _eventBus = eventBus;
            _joystick = joystick;
        }

        public void Tick()
        {
             _eventBus.Invoke(new PlayerInputChangedSignal(_joystick.Value));
        }
    }
}