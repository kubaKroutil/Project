using UnityEngine;

namespace Project.General.Item
{
public abstract class ItemConsumableBaseClass : MonoBehaviour
{
        protected ItemController itemController;
        private void OnEnable()
        {
            Initialization();
            itemController.ConsumeEvent += Consume;
        }
        private void OnDisable()
        {
            itemController.ConsumeEvent -= Consume;
        }
        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
        }
        protected abstract void Consume();
    }
}