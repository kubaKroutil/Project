using Project.Core;
using Project.Player;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemController : MonoBehaviour
    {
        public delegate void ItemEventHandler();
        public event ItemEventHandler ThrowEvent;
        public event ItemEventHandler DropEvent;
        public event ItemEventHandler PickUpEvent;

        public delegate void ItemPickUpActionEventHandler(Transform item);
        public event ItemPickUpActionEventHandler PickUpActionEvent;

        [SerializeField]
        private string itemName;
        private PlayerController playerController;
        public bool IsInInventory { get { return transform.root.CompareTag(References.PlayerTag); } }

        private void OnEnable()
        {
            Initialization();
        }
        private void Initialization()
        {
            transform.tag = References.ItemTag;
            transform.name = itemName;
            playerController = References.Player.GetComponent<PlayerController>();
        }
        public void CallItemThrowEvent()
        {
            RemoveParent();
            ThrowEvent?.Invoke();
            RefreshPlayerInventory();
        }
        public void CallDropEvent()
        {
            RemoveParent();
            DropEvent?.Invoke();
            RefreshPlayerInventory();
        }
        public void CallItemPickUpEvent()
        {
            PickUpEvent?.Invoke();
            RefreshPlayerInventory();
        }
        public void CallItemPickUpActionEvent(Transform item)
        {
            PickUpActionEvent?.Invoke(item);
        }
        private void RefreshPlayerInventory()
        {
            playerController.CallHandsEmptyEvent();
            playerController.CallInventoryChangedEvent();
        }
        private void RemoveParent()
        {
            transform.parent = null;
        }
    }
}