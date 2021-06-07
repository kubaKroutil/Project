using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemPickUp : MonoBehaviour
    {
        private ItemController itemController;
        private void OnEnable()
        {
            Initialization();
            itemController.ItemPickUpActionEvent += PickUp;
        }
        private void OnDisable()
        {
            itemController.ItemPickUpActionEvent -= PickUp;
        }
        private void PickUp(Transform _Transform)
        {
            this.transform.SetParent(_Transform);
            this.itemController.CallItemPickUpEvent();
            transform.gameObject.SetActive(false);
        }

        private void Initialization()
        {
            this.itemController = this.GetComponent<ItemController>();
        }
    }
}