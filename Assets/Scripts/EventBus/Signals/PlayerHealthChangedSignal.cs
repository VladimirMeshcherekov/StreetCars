
    public class PlayerHealthChangedSignal
    {
        public readonly int MaxHealth;
        public readonly int CurrentHealth;

        public PlayerHealthChangedSignal(int maxHealth, int currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
    }
