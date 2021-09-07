using UnityEngine;

namespace Project.General.Item
{
    public class ItemColliders : MonoBehaviour
    {
        private ItemController itemController;
        private Collider[] colliders;
        private void OnEnable()
        {
            Initialization();
            if (itemController.IsInInventory)
            {
                DisableColliders();
            }
            itemController.ThrowEvent += EnableColliders;
            itemController.DropEvent += EnableColliders;
            itemController.PickUpEvent += DisableColliders;
        }
        private void OnDisable()
        {
            itemController.ThrowEvent -= EnableColliders;
            itemController.DropEvent -= EnableColliders;
            itemController.PickUpEvent -= DisableColliders;
        }
        private void EnableColliders()
        {
            foreach (Collider _Collider in colliders)
            {
                _Collider.enabled = true;
            }
        }
        private void DisableColliders()
        {
            foreach (Collider _Collider in colliders)
            {
                _Collider.enabled = false;
            }
        }
        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
            colliders = GetComponentsInChildren<Collider>();
        }
    }
}