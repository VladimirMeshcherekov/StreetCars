using System.Collections.Generic;
using Player.Pause.Interfaces;
using UnityEngine;
using Zenject;

namespace Player.Pause
{
    public class CustomPauseManager : MonoBehaviour, ICustomPauseBehavior, IPauseHandler
    {
        private List<ICustomPauseBehavior> _pausedBehaviorObjects;
        private bool _isGamePaused = false;

        [Inject]
        private void Construct(EventBus eventBus)
        {
            eventBus.Subscribe<SetNewPauseStateSignal>(SetNewPauseState, 0);
        }
        
        public CustomPauseManager()
        {
            _pausedBehaviorObjects = new List<ICustomPauseBehavior>();
        }

        public void AddPausedBehaviorObject(ICustomPauseBehavior newBehaviorObject)
        {
            _pausedBehaviorObjects.Add(newBehaviorObject);
        }

        private void SetNewPauseState(SetNewPauseStateSignal signal)
        {
            _isGamePaused = signal.NewPauseState;
            SetPaused(_isGamePaused);
        }
        
        public void ChangePauseState()
        {
            _isGamePaused = !_isGamePaused;
            SetPaused(_isGamePaused);
        }

        public void SetPaused(bool isPaused)
        {
            foreach (var pauseHandler in _pausedBehaviorObjects)
            {
                pauseHandler.SetPaused(_isGamePaused);
            }
        }
    }
}
