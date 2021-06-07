using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemRigidBody : MonoBehaviour
    {
        private ItemController ItemController;
        private Rigidbody Rigidbody;
        private void OnEnable()
        {
            this.Initialization();
            CheckIfStartInInventory();
            ItemController.ItemThrowEvent += SetKinematicToFalse;
            ItemController.ItemPickUpEvent += SetKinematicToTrue;
        }
        private void OnDisable()
        {
            ItemController.ItemThrowEvent -= SetKinematicToFalse;
            ItemController.ItemPickUpEvent -= SetKinematicToTrue;
        }
        private void CheckIfStartInInventory()
        {
            if (this.transform.root.CompareTag(References.PlayerTag))
            {
                SetKinematicToTrue();
            }
        }
        private void SetKinematicToFalse()
        {
            this.Rigidbody.isKinematic = false;
        }
        private void SetKinematicToTrue()
        {
            this.Rigidbody.isKinematic = true;
        }
        private void Initialization()
        {
            this.ItemController = this.GetComponent<ItemController>();
            this.Rigidbody = this.GetComponent<Rigidbody>();
        }
    }
}