using UnityEngine;

namespace Player
{
    public class PlayerSetup : MonoBehaviour
    {
        [SerializeField] private CarProperties defaultPlayer;
        private CarProperties _currentPlayer;
    
        public void SetPlayer(CarProperties newPlayer)
        {
            _currentPlayer = newPlayer;
        }

        public CarProperties GetPlayer()
        {
            if (_currentPlayer == null)
            {
                return defaultPlayer;
            }

            return _currentPlayer;
        }
    
    }
}