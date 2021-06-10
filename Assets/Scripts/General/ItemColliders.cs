using Project.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemColliders : MonoBehaviour
    {
        private ItemController ItemController;
        private Collider[] Colliders;
        private void OnEnable()
        {
            this.Initialization();
            CheckIfStartInInventory();
            ItemController.ItemThrowEvent += EnableColliders;
            ItemController.ItemPickUpEvent += DisableColliders;
        }
        private void OnDisable()
        {
            ItemController.ItemThrowEvent -= EnableColliders;
            ItemController.ItemPickUpEvent -= DisableColliders;
        }
        private void CheckIfStartInInventory()
        {
            if (this.transform.root.CompareTag(References.PlayerTag))
            {
                DisableColliders();
            }
        }
        private void EnableColliders()
        {
            foreach (Collider _Collider in this.Colliders)
            {
                _Collider.enabled = true;
            }
        }
        private void DisableColliders()
        {
            foreach (Collider _Collider in this.Colliders)
            {
                _Collider.enabled = false;
            }
        }
        private void Initialization()
        {
            this.ItemController = this.GetComponent<ItemController>();
            this.Colliders = GetComponentsInChildren<Collider>();
        }
    }
}