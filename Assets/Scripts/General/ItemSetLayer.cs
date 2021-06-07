using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemSetLayer : MonoBehaviour
    {
        private ItemController itemController;
        public string itemThrowLayer;
        public string itemPickUpLayer;
        private void OnEnable()
        {
            this.Initialization();
            SetLayerOnEnable();
            this.itemController.ItemPickUpEvent += this.SetItemToPickUpLayer;
            this.itemController.ItemThrowEvent += this.SetItemToThrowLayer;
        }
        private void OnDisable()
        {
            this.itemController.ItemPickUpEvent -= this.SetItemToPickUpLayer;
            this.itemController.ItemThrowEvent -= this.SetItemToThrowLayer;
        }
        private void SetItemToThrowLayer()
        {
            SetLayer(this.transform, itemThrowLayer);
        }
        private void SetItemToPickUpLayer()
        {
            SetLayer(this.transform, itemPickUpLayer);
        }
        private void SetLayerOnEnable()
        {
            if (string.IsNullOrEmpty(itemPickUpLayer))
            {
                itemPickUpLayer = References.ItemTag;
            }
            if (string.IsNullOrEmpty(itemPickUpLayer))
            {
                itemPickUpLayer = References.ItemTag;
            }

            if (this.transform.root.CompareTag(References.PlayerTag))
            {
                SetItemToPickUpLayer();
            }
            else
            {
                SetItemToThrowLayer();
            }
        }
        private void SetLayer(Transform transform, string itemLayerName)
        {
            transform.gameObject.layer = LayerMask.NameToLayer(itemLayerName);
            //change layer for each child
            foreach (Transform child in transform)
            {
                SetLayer(child, itemLayerName);
            }
        }
        private void Initialization()
        {
            this.itemController = GetComponent<ItemController>();

        }
    }
}