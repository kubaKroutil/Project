using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    public class TogglePause : MonoBehaviour
    {
        private GameManagerMaster gameManagerMaster;
        [SerializeField]
        private bool isPaused;
        private void OnEnable()
        {
            Initialization();
            gameManagerMaster.MenuToggleEvent += PauseToggle;
            gameManagerMaster.InventoryUIToggleEvent += PauseToggle;
        }

        private void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= PauseToggle;
            gameManagerMaster.InventoryUIToggleEvent -= PauseToggle;
        }

        private void Initialization()
        {
            this.gameManagerMaster = this.GetComponent<GameManagerMaster>();
        }

        private void PauseToggle()
        {
            Time.timeScale = isPaused ? 1 : 0;
            isPaused = !isPaused;
        }

    }
}
