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
            this.Initialization();
            this.playerController.PickItemEvent += PickItem;
            this.playerController.SetItemToPickEvent += SetItemToPick;
        }
        private void OnDisable()
        {
            this.playerController.PickItemEvent -= PickItem;
            this.playerController.SetItemToPickEvent -= SetItemToPick;
        }
        void Update()
        {
            this.CheckItemDistance();
        }

        private void CheckItemDistance()
        {
            if (this.ItemToPick == null) return;
            //Debug.Log(Vector3.Distance(this.transform.position, ItemToPick.position));
            if (Vector3.Distance(this.transform.position, this.ItemToPick.position) < this.pickRange)
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
            this.ItemToPick = item;
        }
        private void PickItem()
        {
            this.ItemToPick.GetComponent<ItemController>().CallItemPickUpActionEvent(PlayerInventoryParent);
            this.SetItemToPick(null);
        }
    }
}