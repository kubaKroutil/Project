using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    public class ToggleMenu : MonoBehaviour
    {
        private GameManagerMaster gameManagerMaster;

        [SerializeField]
        private GameObject menu = null;

        private void Update()
        {
            CheckForToggleMenuRequest();
        }

        private void OnEnable()
        {
            Initialization();
            gameManagerMaster.MenuToggleEvent += MenuToggle;
        }

        private void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= MenuToggle;
        }

        private void Initialization()
        {
            this.gameManagerMaster = this.GetComponent<GameManagerMaster>();
            if (menu == null)
            {
                Debug.LogError("Menu not found! by TogglePause class, gameobject: " + this.gameObject.name);
            }
        }

        private void CheckForToggleMenuRequest()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !gameManagerMaster.isGameOver
                && !gameManagerMaster.isInventoryUIOn)
            {
                gameManagerMaster.CallMenuToggleEvent();
            }
        }

        private void MenuToggle()
        {
            menu.SetActive(!menu.activeSelf);
            gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
        }
    }
}
