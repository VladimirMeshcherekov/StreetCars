using UnityEngine;
using VehicleBehaviour;
using Zenject;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private CarProperties defaultPlayer;
    private CarProperties _currentPlayer;
    
    public void SetPlayer(CarProperties newPlayer)
    {
        print(123);
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