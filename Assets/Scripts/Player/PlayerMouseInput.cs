using Project.Core;
using Project.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Player
{
    public class PlayerMouseInput : MonoBehaviour
    {
        [SerializeField]
        private float labelWidth = 200;
        [SerializeField]
        private float labelHeight = 50;
        [SerializeField]
        private float labelOffset = 10;
        private Transform raycastHit;
        private Vector3 raycastHitPosition;
        private Vector3 raycastHitPositionForGUI;
        private PlayerController playerController;
        private void OnEnable()
        {
            Initialization();
        }
        private void Update()
        {
            if (!CanMouseRaycast())
            {
                ResetRaycastHit();
                return;
            }
            MouseRaycast();
            if (Input.GetMouseButton(0))
            {
                CheckHitLeftButton();
            }
        }
        private void Initialization()
        {
            playerController = GetComponent<PlayerController>();
        }
        private void CheckHitLeftButton()
        {
            //Check if it item
            if (IsTransformItem())
            {
                playerController.CallSetItemToPickEvent(raycastHit);
            }
            else
            {
               playerController.CallSetItemToPickEvent(null);
            }
            //then move
            playerController.CallMoveEvent(raycastHitPosition);
        }
        private bool CanMouseRaycast()
        {
            return !EventSystem.current.IsPointerOverGameObject() && Time.timeScale != 0;
        }
        private bool MouseRaycast()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (!IsPlayer(hit.transform))
                {
                    SetRaycastHit(hit);
                    return true;
                }
            }
            ResetRaycastHit();
            return false;
        }
        private bool IsTransformItem()
        {
            return raycastHit.transform.CompareTag(References.ItemTag);
        }
        private bool IsPlayer(Transform transform)
        {
            return transform.root.CompareTag(References.PlayerTag);
        }
        private void SetRaycastHit(RaycastHit hit)
        {
            raycastHit = hit.transform;
            raycastHitPosition = hit.point;
        }
        private void ResetRaycastHit()
        {
            this.raycastHit = null;
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
                GUI.Label(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, labelWidth, labelHeight), raycastHit.name);
            }
        }
    }
}