using UnityEngine;

namespace Project.Core
{
    public class TogglePause : MonoBehaviour
    {
        private GameManagerMaster gameManagerMaster;
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
            gameManagerMaster = GetComponent<GameManagerMaster>();
        }

        private void PauseToggle()
        {
            Time.timeScale = gameManagerMaster.IsPaused ? 1 : 0;
        }
    }
}
