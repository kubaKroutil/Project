using UnityEngine;

namespace Project.General.Item
{
    public class ItemThrow : MonoBehaviour
    {
        private ItemController itemController;
        private Rigidbody myRigidbody;
        [SerializeField]
        private float throwForce;

        private void OnEnable()
        {
            Initialization();
            itemController.ThrowEvent += ThrowAction;
        }
        private void OnDisable()
        {
            itemController.ThrowEvent -= ThrowAction;
        }
        private void ThrowAction()
        {
            myRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
            Debug.Log(throwForce +" " + myRigidbody.velocity.magnitude);
        }

        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
            myRigidbody = GetComponent<Rigidbody>();
        }
    }
}