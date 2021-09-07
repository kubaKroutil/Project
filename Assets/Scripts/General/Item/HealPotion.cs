using UnityEngine;

namespace Project.General.Item
{
    public class HealPotion : ItemConsumableBaseClass
    {
        [SerializeField]
        private float HealPower = 50;
        protected override void Consume()
        {
            itemController.PlayerController.CallPlayerHealthIncreaseEvent(HealPower);
            transform.parent = null;
            gameObject.SetActive(false);
        }
    }
}