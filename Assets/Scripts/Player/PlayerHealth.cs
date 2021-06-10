using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        private int hitPoints;
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
        private void HealthIncrease(int _HP)
        {
            hitPoints += _HP;
        }
        private void HealthDecrease(int _HP)
        {
            hitPoints -= _HP;
            //SET GAME OVER
        }
        private void SetUI()
        {
            healthText.text = hitPoints.ToString();
        }
        private void Initialization()
        {
            this.playerController = this.transform.root.GetComponent<PlayerController>();
        }
    }
}