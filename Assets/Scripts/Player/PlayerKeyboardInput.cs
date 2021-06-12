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
            if (!CanPlay()) return;
            if (playerInventory.IsItemInHands)
            {
                CheckItemActions();
            }
        }

        private void CoreMechanics()
        {
            CheckForInventory();
            CheckForToggleMenuRequest();
        }
        private void CheckItemActions()
        {
            if (HasItemInHands())
            {
                CheckForDropAction();
                CheckForThrowAction();
            }
            //weapon action
        }

        private void CheckForDropAction()
        {
            if (Input.GetButtonDown(dropButtonName))
            {
                playerInventory.currentItem.GetComponent<ItemController>().CallDropEvent();
            }
        }
        private void CheckForThrowAction()
        {
            if (Input.GetButtonDown(throwButtonName))
            {
                playerInventory.currentItem.GetComponent<ItemController>().CallItemThrowEvent();
            }
        }

        private bool HasItemInHands()
        {
            return playerInventory.currentItem != null && IsTransformItem(playerInventory.currentItem);
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
        private bool IsTransformItem(Transform transform)
        {
            return transform.CompareTag(References.ItemTag);
        }
    }
}