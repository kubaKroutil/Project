using Project.General;
using Project.General.Item;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Player
{
    public class PlayerDetectItem : MonoBehaviour
    {
        [SerializeField]
        private Transform PlayerInventoryParent;
        [SerializeField]
        private Transform raycastHit;
        [SerializeField]
        private Transform ItemToPick;
        private PlayerController playerController;
        private void OnEnable()
        {
            this.Initialization();
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
            if (ItemToPick != null)
            {
                CheckItemDistance();
            }
        }

        private void CheckItemDistance()
        {
            //Debug.Log(Vector3.Distance(this.transform.position, ItemToPick.position));
            if (Vector3.Distance(this.transform.position, ItemToPick.position) < 1f)
            {
                this.playerController.CallPickItemEvent();
            }
        }

        private void Initialization()
        {
            this.playerController = this.GetComponent<PlayerController>();
        }
        private void SetItemToPick(Transform item)
        {
            ItemToPick = item;
        }
        private void PickItem()
        {
            ItemToPick.GetComponent<ItemController>().CallItemPickUpActionEvent(PlayerInventoryParent);
            ItemToPick = null;
        }
    }
}