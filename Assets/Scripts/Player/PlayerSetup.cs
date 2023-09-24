using UnityEngine;
using VehicleBehaviour;
using Zenject;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private WheelVehicle defaultPlayer;
    private WheelVehicle _currentPlayer;
    
    public void SetPlayer(WheelVehicle newPlayer)
    {
        print(123);
        _currentPlayer = newPlayer;
    }

    public WheelVehicle GetPlayer()
    {
        if (_currentPlayer == null)
        {
            return defaultPlayer;
        }

        return _currentPlayer;
    }
    
}