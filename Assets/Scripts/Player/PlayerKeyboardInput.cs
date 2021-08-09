using Project.Core;
using Project.General.Item;
using UnityEngine;

namespace Project.Player
{
    public class PlayerKeyboardInput : MonoBehaviour
    {
        [SerializeField]
        private string dropButtonName;
        [SerializeField]
        private string throwButtonName;
        [SerializeField]
        private string toggleInventoryButton;
        [SerializeField]
        private string toggleMenuButton;
        private PlayerController playerController;
        private PlayerInventory playerInventory;
        private void OnEnable()
        {
            Initialization();
        }
        private void Update()
        {
            CoreMechanics();
            if (!CanPlay() || playerInventory.AreHandsEmpty) return;
            CheckItemActions();
        }

        private void CoreMechanics()
        {
            CheckForInventory();
            CheckForToggleMenuRequest();
        }
        private void CheckItemActions()
        {
            CheckForDropAction();
            CheckForThrowAction();
            CheckForConsumeAction();
        }

        private void CheckForDropAction()
        {
            if (Input.GetButtonDown(dropButtonName))
            {
                playerInventory.CurrentItem.GetComponent<ItemController>().CallDropEvent();
            }
        }
        private void CheckForThrowAction()
        {
            if (Input.GetButtonDown(throwButtonName))
            {
                playerInventory.CurrentItem.GetComponent<ItemController>().CallItemThrowEvent();
            }
        }
        private void CheckForConsumeAction()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                playerInventory.CurrentItem.GetComponent<ItemController>().CallItemConsumeEvent();
            }
        }

        private void Initialization()
        {
            playerController = GetComponent<PlayerController>();
            playerInventory = GetComponent<PlayerInventory>();
        }
        private bool CanPlay()
        {
            return !playerController.GameManagerMaster.IsPaused;
        }
        private void CheckForInventory()
        {
            if (Input.GetButtonDown(toggleInventoryButton) && playerController.GameManagerMaster.CanOpenInventory)
            {
                playerController.GameManagerMaster.CallInventoryUIToggleEvent();
            }
        }
        private void CheckForToggleMenuRequest()
        {
            if (Input.GetButtonDown(toggleMenuButton) && playerController.GameManagerMaster.CanOpenMenu)
            {
                playerController.GameManagerMaster.CallMenuToggleEvent();
            }
        }
    }
}