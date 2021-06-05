using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        
        private PlayerController playerController;
        [SerializeField]
        private int HP;
        public Text healthText;
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
            HP += _HP;
        }
        private void HealthDecrease(int _HP)
        {
            HP -= _HP;
            //SET GAME OVER
            playerController.GameManagerMaster.CallGameOverEvent();
        }
        private void SetUI()
        {
            healthText.text = HP.ToString();
        }
        private void Initialization()
        {
            this.playerController = this.transform.root.GetComponent<PlayerController>();
        }
    }
}