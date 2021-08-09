using Project.Core;
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
        private Transform raycastHitTransform;
        private Vector3 raycastHitPosition;
        private PlayerController playerController;
        private Camera mainCamera;

        private bool IsRaycastHitItem => raycastHitTransform != null && raycastHitTransform.transform.CompareTag(References.ItemTag);

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
            mainCamera = Camera.main;
        }
        private void CheckHitLeftButton()
        {
            //Pick
            playerController.CallSetItemToPickEvent(IsRaycastHitItem? raycastHitTransform : null);
            //Move
            playerController.CallMoveEvent(raycastHitPosition);
        }
        private bool CanMouseRaycast()
        {
            return !EventSystem.current.IsPointerOverGameObject() && !playerController.GameManagerMaster.IsPaused;
        }
        private bool MouseRaycast()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
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
        
        private bool IsPlayer(Transform transform)
        {
            return transform.root.CompareTag(References.PlayerTag);
        }
        private void SetRaycastHit(RaycastHit hit)
        {
            raycastHitTransform = hit.transform;
            raycastHitPosition = hit.point;
        }
        private void ResetRaycastHit()
        {
            raycastHitTransform = null;
        }

        private void OnGUI()
        {
            if (raycastHitTransform != null)
            {
                //Debug.Log(Screen.height + " - " + Input.mousePosition.y + "=" + (Screen.height - Input.mousePosition.y));
                //calculate y position
                //float yPos = Screen.height - Input.mousePosition.y > 0 ?
                //             Screen.height - Input.mousePosition.y - labelOffset
                //            : Screen.height - Input.mousePosition.y + labelOffset;
                GUI.Label(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, labelWidth, labelHeight), raycastHitTransform.name);
            }
        }
    }
}