using Project.General;
using Project.General.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Player
{
public class PlayerDetectItem : MonoBehaviour
{
        [Tooltip("What layers is being used for items.")]
        public LayerMask layerToDetect;
        [Tooltip("what transform will the ray be fired from?")]
        public Transform rayTransformPivot;
        [Tooltip("the editor input button that will be used for picking items")]
        public string buttonPickUp;
        [SerializeField]
        private Transform PlayerInventoryParent;
        [SerializeField]
        private readonly float labelWidth = 200;
        [SerializeField]
        private readonly float labelHeight = 50;
        [SerializeField]
        private readonly float labelOffset = 10;

        private Transform itemAvailableForPickup;
        // Update is called once per frame
        void Update()
        {
            CastRayForDetectingItems();
            CheckForItemPickupAttempt();
        }

        void CastRayForDetectingItems()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (!hit.transform.root.CompareTag(References.PlayerTag) && hit.transform.CompareTag(References.ItemTag))
                {
                    itemAvailableForPickup = hit.transform;
                }
                else
                {
                    itemAvailableForPickup = null;
                }
            }
            else
            {
                itemAvailableForPickup = null;
            }
        }

        void CheckForItemPickupAttempt()
        {
            if (Input.GetButtonDown(buttonPickUp) && Time.timeScale > 0 && itemAvailableForPickup != null)
            {
                itemAvailableForPickup.GetComponent<ItemController>().CallItemPickUpActionEvent(PlayerInventoryParent);
                itemAvailableForPickup = null;
            }
        }

        void OnGUI()
        {
            if (itemAvailableForPickup != null)
            {
                Debug.Log(Screen.height + " - " + Input.mousePosition.y + "=" + (Screen.height - Input.mousePosition.y));
                //calculate y position
                float yPos = Screen.height - Input.mousePosition.y > 0 ?
                             Screen.height - Input.mousePosition.y - labelOffset
                            :Screen.height - Input.mousePosition.y + labelOffset;
                GUI.Label(new Rect(Input.mousePosition.x, yPos, labelWidth, labelHeight), itemAvailableForPickup.name);
            }
        }
    }
}