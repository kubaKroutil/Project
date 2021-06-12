using Project.General.Item;
using UnityEngine;

namespace Project.Player
{
    public class PlayerDetectItem : MonoBehaviour
    {
        [SerializeField]
        private Transform PlayerInventoryParent;
        [SerializeField]
        private float pickRange = 1f;
        private Transform ItemToPick;
        private PlayerController playerController;
        private void OnEnable()
        {
            Initialization();
            playerController.PickItemEvent += PickItem;
            playerController.SetItemToPickEvent += SetItemToPick;
        }
        private void OnDisable()
        {
            playerController.PickItemEvent -= PickItem;
            playerController.SetItemToPickEvent -= SetItemToPick;
        }
        void Update()
        {
            CheckItemDistance();
        }

        private void CheckItemDistance()
        {
            if (ItemToPick != null && Vector3.Distance(transform.position, ItemToPick.position) < pickRange)
            {
                playerController.CallPickItemEvent();
            }
        }

        private void Initialization()
        {
            playerController = GetComponent<PlayerController>();
        }
        private void SetItemToPick(Transform item)
        {
            ItemToPick = item;
        }
        private void PickItem()
        {
            ItemToPick.GetComponent<ItemController>().CallItemPickUpActionEvent(PlayerInventoryParent);
            SetItemToPick(null);
        }
    }
}