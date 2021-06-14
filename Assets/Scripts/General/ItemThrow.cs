using UnityEngine;

namespace Project.General.Item
{
    public class ItemThrow : MonoBehaviour
    {
        private ItemController itemController;
        private Rigidbody myRigidbody;
        private void OnEnable()
        {
            Initialization();
            itemController.ThrowEvent += ThrowAction;
        }
        private void OnDisable()
        {
            itemController.ThrowEvent -= ThrowAction;
        }
        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
            myRigidbody = GetComponent<Rigidbody>();
        }
        private void ThrowAction()
        {
            transform.parent = null;
            myRigidbody.isKinematic = false;
            myRigidbody.AddForce(transform.forward * itemController.PlayerController.ThrowForce, ForceMode.Impulse);
        }
    }
}