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
            hitPoints += _HP;
            SetUI();
        }
        private void HealthDecrease(float _HP)
        {
            hitPoints -= _HP;
            SetUI();
            //SET GAME OVER
        }
        private void SetUI()
        {
            healthText.text = hitPoints.ToString();
        }
        private void Initialization()
        {
            playerController = transform.root.GetComponent<PlayerController>();
        }
    }
}