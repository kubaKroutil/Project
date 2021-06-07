using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemSetPosition : MonoBehaviour
    {
        private ItemController itemController;
        public Vector3 localPosition;
        private void OnEnable()
        {
            this.Initialization();
            SetPositionOnPlayer();
            itemController.ItemPickUpEvent += SetPositionOnPlayer;
        }
        private void OnDisable()
        {
            itemController.ItemPickUpEvent -= SetPositionOnPlayer;
        }
        private void SetPositionOnPlayer()
        {
            if (transform.root.CompareTag(References.PlayerTag))
            {
                this.transform.localPosition = this.localPosition;
            }
        }
        private void Initialization()
        {
            this.itemController = GetComponent<ItemController>();
        }
    }
}