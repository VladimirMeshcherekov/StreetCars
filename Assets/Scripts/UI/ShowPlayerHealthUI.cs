using UnityEngine;
using Zenject;

namespace UI
{
    public class ShowPlayerHealthUI : MonoBehaviour
    {
        private EventBus _eventBus;
        [SerializeField] private RectTransform playerHealth;

        [Inject]
        private void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
            eventBus.Subscribe<PlayerHealthChangedSignal>(ChangePlayerHealthUI, 1);
        }

        private void ChangePlayerHealthUI(PlayerHealthChangedSignal signal)
        {
            playerHealth.localScale = new Vector3((float)signal.CurrentHealth / (float)signal.MaxHealth, 1, 1);
        }

    }
}