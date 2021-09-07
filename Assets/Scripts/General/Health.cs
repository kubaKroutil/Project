using UnityEngine;

namespace Project.General
{
    public class Health
{
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }
        public bool IsDead { get { return CurrentHealth <= 0; } }
        public Health(float currentHealth, float maxHealth) : this(currentHealth)
        {
            MaxHealth = maxHealth;
        }
        public Health(float currentHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = currentHealth;
        }
        public void ChangeHealth(float health)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + health, 0, MaxHealth);
        }
    }
}