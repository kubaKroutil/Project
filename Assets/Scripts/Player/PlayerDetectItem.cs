using Project.General.Item;
using UnityEngine;

namespace Project.Player
{
    public class PlayerDetectItem : MonoBehaviour
    {
        [SerializeField]
        private Transform playerInventoryParent;
        [SerializeField]
        private float pickRange = 1f;
        private Transform itemToPick;
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
            if (itemToPick != null && Vector3.Distance(transform.position, itemToPick.position) < pickRange)
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
            itemToPick = item;
        }
        private void PickItem()
        {
            itemToPick.GetComponent<ItemController>().CallItemPickUpActionEvent(playerInventoryParent);
            SetItemToPick(null);
        }
    }
}