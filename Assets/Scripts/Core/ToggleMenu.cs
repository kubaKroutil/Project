using UnityEngine;

namespace Project.Core
{
    public class ToggleMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject menu;
        private GameManagerMaster gameManagerMaster;
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
                Debug.LogError("InventoryUI not found! by ToggleInventory class, gameobject: " + gameObject.name);
            }
        }
        private void MenuToggle()
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
