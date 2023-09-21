using System;

namespace Player
{
    public class PlayerWallet 
    {
        public int Coins { get; private set; }
        private WalletSaveSystem _walletSaveSystem;
        public PlayerWallet()
        {
            _walletSaveSystem = new WalletSaveSystem();
            Coins = _walletSaveSystem.LoadFromFile().Coins;
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
