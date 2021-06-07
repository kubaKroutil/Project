using Project.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
public class ItemController : MonoBehaviour
{
        public delegate void ItemEventHandler();
        public event ItemEventHandler ItemThrowEvent;
        public event ItemEventHandler ItemPickUpEvent;

        public delegate void ItemPickUpActionEventHandler(Transform item);
        public event ItemPickUpActionEventHandler ItemPickUpActionEvent;

        private PlayerController playerController;
        public string Name { get; private set; }
        private void OnEnable()
        {
            Initialization();
            this.playerController = References.Player.GetComponent<PlayerController>();
        }

        private void Initialization()
        {
            this.transform.tag = References.ItemTag;
            this.transform.name = References.ItemTag;
        }

        public void CallItemThrowEvent()
        {
            if (ItemThrowEvent!= null)
            {
                this.ItemThrowEvent();
                
            }
            this.playerController.CallHandsEmptyEvent();
            this.playerController.CallInventoryChangedEvent();
        }
        public void CallItemPickUpEvent()
        {
            if (ItemThrowEvent != null)
            {
                this.ItemThrowEvent();
                
            }
            this.playerController.CallHandsEmptyEvent();
            this.playerController.CallInventoryChangedEvent();
        }
        public void CallItemPickUpActionEvent(Transform item)
        {
            ItemPickUpActionEvent?.Invoke(item);
        }
    }
}