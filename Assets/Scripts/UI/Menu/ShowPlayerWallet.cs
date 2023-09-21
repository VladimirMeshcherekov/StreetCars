using System;
using Player;
using TMPro;
using UnityEngine;
using Zenject;

public class ShowPlayerWallet : MonoBehaviour
{
    [SerializeField] private string textBeforeValue;
    [SerializeField] private TMP_Text playerWallerValue;

    private PlayerWallet _playerWallet;

    [Inject]
    void Construct(PlayerWallet playerWallet)
    {
        _playerWallet = playerWallet;
    }

    private void Start()
    {
        playerWallerValue.text = textBeforeValue + _playerWallet.Coins;
    }
}
