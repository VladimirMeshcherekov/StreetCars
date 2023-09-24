using System;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class SetPlayerButton : MonoBehaviour
    {
        [HideInInspector] public CarProperties thisButtonCarProperties;
        private EventBus _eventBus;

        [Inject]
        private void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void SetPlayerThrowUIButton()
        {
            if (thisButtonCarProperties == null)
            {
                throw new Exception("car to select is null");
            }
            _eventBus.Invoke(new SelectNewItemSignal(thisButtonCarProperties));
        }
        
    }
}
