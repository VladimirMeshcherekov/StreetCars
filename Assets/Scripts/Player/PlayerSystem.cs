namespace Player
{
    public class PlayerSystem
    {
        private int _playerHealth;
        private int _currentPlayerHealth;
        private EventBus _eventBus;

        public void SetupPlayer(EventBus eventBus, int playerHealth)
        {
            _eventBus = eventBus;
            _playerHealth = playerHealth;
            _currentPlayerHealth = playerHealth;
            _eventBus.Invoke(new PlayerHealthChangedSignal(_playerHealth, _currentPlayerHealth));
            
        }
        
        public void SetDamage(int damage)
        {
            _currentPlayerHealth -= damage;
            
            if (_currentPlayerHealth <= 0)
            {
                _currentPlayerHealth = 0;
                _eventBus.Invoke(new PlayerDiedSignal());
                _eventBus.Invoke(new SetNewPauseStateSignal(true));
            }
            _eventBus.Invoke(new PlayerHealthChangedSignal(_playerHealth, _currentPlayerHealth));
        }
    }
}