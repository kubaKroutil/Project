using UnityEngine;

namespace Project.Core
{
    public class ToggleMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject menu;
        private GameManagerMaster gameManagerMaster;
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
            gameManagerMaster = GetComponent<GameManagerMaster>();
            if (menu == null)
            {
                Debug.LogError("InventoryUI not found! by ToggleInventory class, gameobject: " + this.gameObject.name);
            }
        }

        private void CheckForToggleMenuRequest()
        {
            if (Input.GetButtonDown(References.ToggleMenuButton) && gameManagerMaster.CanOpenMenu)
            {
                gameManagerMaster.CallMenuToggleEvent();
            }
        }

        private void MenuToggle()
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
