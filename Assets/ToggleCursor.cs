using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    public class ToggleCursor : MonoBehaviour
    {
        private GameManagerMaster gameManagerMaster;
        private bool IsCursorLocked;

        private void Update()
        {
            CheckCursor();
        }

        private void OnEnable()
        {
            Initialization();
            gameManagerMaster.MenuToggleEvent += CursorToggle;
            gameManagerMaster.InventoryUIToggleEvent += CursorToggle;
        }

        private void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= CursorToggle;
            gameManagerMaster.InventoryUIToggleEvent -= CursorToggle;
        }

        private void Initialization()
        {
            this.gameManagerMaster = this.GetComponent<GameManagerMaster>();
        }

        private void CheckCursor()
        {
            //if (IsCursorLocked)
            //{
            //    Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.visible = false;
            //}
            //else
            //{
            //    Cursor.lockState = CursorLockMode.None;
            //    Cursor.visible = true;
            //}
        }
        private void CursorToggle()
        {
            IsCursorLocked = !IsCursorLocked;
        }
    }
}
