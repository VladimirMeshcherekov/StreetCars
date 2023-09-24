using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShopPopup : MonoBehaviour
{
    [SerializeField] private GameObject popupWindow;
    [SerializeField] private Image popupBackground;
    [SerializeField] private List<GameObject> elementsToHide;

    [SerializeField] private float showPopupTime;
    [SerializeField] private Color backgroundAlfa;

    public void HidePopup()
    {
        ShowOtherUIElements(true);
        popupWindow.transform.DOScale(Vector3.zero, showPopupTime);
        popupBackground.DOFade(0, showPopupTime);
        transform.DOScale(Vector3.zero, showPopupTime);
    }

    public void ShowPopup()
    {
        ShowOtherUIElements(false);
        popupWindow.transform.DOScale(Vector3.one, showPopupTime);
        popupBackground.DOFade(backgroundAlfa.a, showPopupTime);
        transform.localScale = Vector3.one;
    }

    private void ShowOtherUIElements(bool elementState)
    {
        foreach (var element in elementsToHide)
        {
            element.SetActive(elementState);
        }
    }
}