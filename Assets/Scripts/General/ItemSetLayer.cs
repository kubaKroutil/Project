using Project.Core;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemSetLayer : MonoBehaviour
    {
        [SerializeField]
        private string itemThrowLayer;
        [SerializeField]
        private string itemPickUpLayer;
        private ItemController itemController;
        private void OnEnable()
        {
            Initialization();
            SetLayerOnEnable();
            itemController.PickUpEvent += SetItemToPickUpLayer;
            itemController.ThrowEvent += SetItemToThrowLayer;
            itemController.DropEvent += SetItemToThrowLayer;
        }
        private void OnDisable()
        {
            itemController.PickUpEvent -= SetItemToPickUpLayer;
            itemController.ThrowEvent -= SetItemToThrowLayer;
            itemController.DropEvent -= SetItemToThrowLayer;
        }
        private void SetItemToThrowLayer()
        {
            SetLayer(transform, itemThrowLayer);
        }
        private void SetItemToPickUpLayer()
        {
            SetLayer(transform, itemPickUpLayer);
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

            if (itemController.IsInInventory)
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
            foreach (Transform child in transform)
            {
                SetLayer(child, itemLayerName);
            }
        }
        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
        }
    }
}