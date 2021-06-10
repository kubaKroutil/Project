using Project.Core;
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
            if (transform.root.CompareTag(References.PlayerTag))
            {
                SetKinematicToTrue();
            }
        }
        private void SetKinematicToFalse()
        {
            Rigidbody.isKinematic = false;
        }
        private void SetKinematicToTrue()
        {
            Rigidbody.isKinematic = true;
        }
        private void Initialization()
        {
            ItemController = GetComponent<ItemController>();
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}