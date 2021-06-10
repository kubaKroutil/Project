using UnityEngine;

namespace Project.Core
{
    public class GameManagerMaster : MonoBehaviour
    {
        public delegate void GameManagerEventHandler();
        public event GameManagerEventHandler MenuToggleEvent;
        public event GameManagerEventHandler InventoryUIToggleEvent;

        public bool isGameOver = false;
        public bool isInventoryUIOn = false;
        public bool isMenuOn = false;
        public bool CanOpenMenu { get { return !isGameOver && !isInventoryUIOn; } }
        public bool CanOpenInventory { get { return !isGameOver && !isMenuOn; } }
        public bool IsPaused { get { return isInventoryUIOn || isMenuOn; } }

        public void CallMenuToggleEvent()
        {
            if (MenuToggleEvent!= null)
            {
                MenuToggleEvent();
                isMenuOn = !isMenuOn;
            }
        }
        public void CallInventoryUIToggleEvent()
        {
            if (InventoryUIToggleEvent != null)
            {
                InventoryUIToggleEvent();
                isInventoryUIOn = !isInventoryUIOn;
            }
        }
    }
}
