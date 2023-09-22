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
    private EventBus _eventBus;

    [Inject]
    void Construct(PlayerWallet playerWallet, EventBus eventBus)
    {
        _playerWallet = playerWallet;
        _eventBus = eventBus;
    }

    private void Start()
    {
        _eventBus.Subscribe<PlayerWalletValueChangedSignal>(PlayerWalletValueChanged, 0);
        UpdateWalletValue();
    }

    private void PlayerWalletValueChanged(PlayerWalletValueChangedSignal signal)
    {
        UpdateWalletValue();
    }

    private void UpdateWalletValue()
    {
        playerWallerValue.text = textBeforeValue + _playerWallet.Coins;
    }
}