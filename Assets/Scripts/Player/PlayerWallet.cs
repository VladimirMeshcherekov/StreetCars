using System;
using Services;
using UnityEngine;

namespace Player
{
    public class PlayerWallet 
    {
        public int Coins { get; private set; }
        private SaveService<PlayerWalletSaveProperties> _walletSaveSystem;
        private string SaveFilePath { get; } = Application.persistentDataPath + "wallet.cars";

        public PlayerWallet()
        {
            _walletSaveSystem = new SaveService<PlayerWalletSaveProperties>(SaveFilePath);
            Coins = _walletSaveSystem.LoadFromFile<PlayerWalletSaveProperties>().Coins;
        }

        public bool TryAddCoins(int value)
        {
            Coins += value;
            _walletSaveSystem.SaveToFile(new PlayerWalletSaveProperties(Coins));
            return true;
        }

        public bool TryToSpendCoins(int price)
        {
            if (price > Coins)
            {
                return false;
            }

            Coins -= price;
            _walletSaveSystem.SaveToFile(new PlayerWalletSaveProperties(Coins));
            return true;
        }
    }

    [Serializable]
    public struct PlayerWalletSaveProperties
    {
        public int Coins;

        public PlayerWalletSaveProperties(int coins)
        {
            Coins = coins;
        }
    }
}
