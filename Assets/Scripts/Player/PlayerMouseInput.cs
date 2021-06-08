using Project.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Player
{
    public class PlayerMouseInput : MonoBehaviour
    {
        [SerializeField]
        private readonly float labelWidth = 200;
        [SerializeField]
        private readonly float labelHeight = 50;
        [SerializeField]
        private readonly float labelOffset = 10;
        [SerializeField]
        private Transform raycastHit;
        private Vector3 raycastHitPosition;
        private PlayerController playerController;
        private void OnEnable()
        {
            this.Initialization();
        }
        private void Update()
        {
            if (MouseRaycast() && Input.GetMouseButtonDown(0))
            {
                CheckHit();
            }
            
        }
        private void Initialization()
        {
            this.playerController = this.GetComponent<PlayerController>();
        }
        private void CheckHit()
        {
            //Check if it item
            if (this.IsTransformItem()) this.playerController.CallSetItemToPickEvent(raycastHit);
            else this.playerController.CallSetItemToPickEvent(null);
            //then move
            this.playerController.CallMoveEvent(this.raycastHitPosition);
        }
        private bool MouseRaycast()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                this.raycastHit = hit.transform;
                this.raycastHitPosition = hit.point;
                return true;
            }
            return false;
        }
        private bool IsTransformItem()
        {
            return !raycastHit.root.CompareTag(References.PlayerTag) && raycastHit.transform.CompareTag(References.ItemTag);
        }

        private void OnGUI()
        {
            if (raycastHit != null)
            {
                //Debug.Log(Screen.height + " - " + Input.mousePosition.y + "=" + (Screen.height - Input.mousePosition.y));
                //calculate y position
                float yPos = Screen.height - Input.mousePosition.y > 0 ?
                             Screen.height - Input.mousePosition.y - labelOffset
                            : Screen.height - Input.mousePosition.y + labelOffset;
                GUI.Label(new Rect(Input.mousePosition.x, yPos, labelWidth, labelHeight), raycastHit.name);
            }
        }
    }
}