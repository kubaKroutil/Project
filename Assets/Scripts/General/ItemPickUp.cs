using UnityEngine;

namespace Project.General.Item
{
    public class ItemPickUp : MonoBehaviour
    {
        private ItemController itemController;
        private void OnEnable()
        {
            Initialization();
            itemController.PickUpActionEvent += PickUp;
        }
        private void OnDisable()
        {
            itemController.PickUpActionEvent -= PickUp;
        }
        private void PickUp(Transform _Transform)
        {
            transform.SetParent(_Transform);
            itemController.CallItemPickUpEvent();
            transform.gameObject.SetActive(false);
        }
        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
        }
    }
}