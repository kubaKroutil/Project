using Project.Core;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemRigidBody : MonoBehaviour
    {
        private ItemController itemController;
        private Rigidbody myRigidbody;
        private void OnEnable()
        {
            Initialization();
            CheckIfStartInInventory();
            itemController.ThrowEvent += SetKinematicToFalse;
            itemController.DropEvent += SetKinematicToFalse;
            itemController.PickUpEvent += SetKinematicToTrue;
        }
        private void OnDisable()
        {
            itemController.ThrowEvent -= SetKinematicToFalse;
            itemController.DropEvent += SetKinematicToFalse;
            itemController.PickUpEvent -= SetKinematicToTrue;
        }
        private void CheckIfStartInInventory()
        {
            if (itemController.IsInInventory)
            {
                SetKinematicToTrue();
            }
        }
        private void SetKinematicToFalse()
        {
            myRigidbody.isKinematic = false;
        }
        private void SetKinematicToTrue()
        {
            myRigidbody.isKinematic = true;
        }
        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
            myRigidbody = GetComponent<Rigidbody>();
        }
    }
}