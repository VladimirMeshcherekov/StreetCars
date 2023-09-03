using System.Collections.Generic;
using DG.Tweening;
using Player.Pause.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ShowPausePopup : MonoBehaviour, ICustomPauseBehavior
    {
        [SerializeField] private GameObject popupWindow;
        [SerializeField] private Image popupBackground;
        [SerializeField] private List<GameObject> elementsToHide;

        [SerializeField] private float showPopupTime;
        [SerializeField] private Color backgroundAlfa;

        [Inject]
        private void Construct(IPauseHandler pauseHandler)
        {
            pauseHandler.AddPausedBehaviorObject(this);
        }

        public void SetPaused(bool isPaused)
        {
            if (isPaused == true)
            {
                ShowPopup();
            }

            if (isPaused == false)
            {
                HidePopup();
            }
        }

        private void HidePopup()
        {
            ShowOtherUIElements(true);
            popupWindow.transform.DOScale(Vector3.zero, showPopupTime);
            popupBackground.DOFade(0, showPopupTime);
        }

        private void ShowPopup()
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