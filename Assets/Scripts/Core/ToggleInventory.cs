using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    public class ToggleInventory : MonoBehaviour
    {
        private GameManagerMaster gameManagerMaster;
        [SerializeField]
        private GameObject InventoryUI = null;
        [SerializeField]
        private string ToggleInventoryButton = string.Empty;

        private void Update()
        {
            CheckForInput();
        }

        private void OnEnable()
        {
            Initialization();
        }



        private void Initialization()
        {
            this.gameManagerMaster = this.GetComponent<GameManagerMaster>();
            if (InventoryUI == null)
            {
                Debug.LogError("InventoryUI not found! by ToggleInventory class, gameobject: " + this.gameObject.name);
            }
        }

        private void CheckForInput()
        {
            if (Input.GetButtonDown(ToggleInventoryButton) && !gameManagerMaster.isMenuOn
                && !gameManagerMaster.isGameOver)
            {
                InventoryToggle();
            }
        }
        public void InventoryToggle()
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
            gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
            gameManagerMaster.CallInventoryUIToggleEvent();
        }
    }
}
