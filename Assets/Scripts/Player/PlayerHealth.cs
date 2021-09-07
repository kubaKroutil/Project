using Project.General;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        private float hitPoints;
        [SerializeField]
        private Text healthText;
        private PlayerController playerController;
        private Health health;
        private void OnEnable()
        {
            Initialization();
            SetUI();
            playerController.PlayerHealthIncreaseEvent += HealthIncrease;
            playerController.PlayerHealthDecreaseEvent += HealthDecrease;
        }
        private void OnDisable()
        {
            playerController.PlayerHealthIncreaseEvent -= HealthIncrease;
            playerController.PlayerHealthDecreaseEvent -= HealthDecrease;
        }
        private void HealthIncrease(float _HP)
        {
            health.ChangeHealth(_HP);
            SetUI();
        }
        private void HealthDecrease(float _HP)
        {
            health.ChangeHealth(-_HP);
            SetUI();
            //SET GAME OVER
        }
        private void SetUI()
        {
            healthText.text = health.CurrentHealth.ToString();
        }
        private void Initialization()
        {
            playerController = transform.root.GetComponent<PlayerController>();
            health = new Health(hitPoints);
        }
    }
}