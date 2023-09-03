using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ShowGameOverPopup : MonoBehaviour
    {
        [SerializeField] private GameObject popupWindow;
        [SerializeField] private Image popupBackground;
        [SerializeField] private List<GameObject> elementsToHide;

        [SerializeField] private float showPopupTime;
        [SerializeField] private Color backgroundAlfa;

        [Inject]
        private void Construct(EventBus eventBus)
        {
            eventBus.Subscribe<PlayerDiedSignal>(PlayerDied, 0);
        }

        private void PlayerDied(PlayerDiedSignal signal)
        {
            ShowOtherUIElements(false);
            popupWindow.transform.DOScale(Vector3.one, showPopupTime);
            popupBackground.DOFade(backgroundAlfa.a, showPopupTime);
        }

        private void ShowOtherUIElements(bool elementState)
        {
            foreach (var element in elementsToHide)
            {
                element.SetActive(elementState);
            }
        }
    }
}