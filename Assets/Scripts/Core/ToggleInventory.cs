using UnityEngine;

namespace Project.Core
{
    public class ToggleInventory : MonoBehaviour
    {
        [SerializeField]
        private GameObject InventoryUI;
        private GameManagerMaster gameManagerMaster;
        private void OnEnable()
        {
            Initialization();
            gameManagerMaster.InventoryUIToggleEvent += InventoryToggle;
        }

        private void OnDisable()
        {
            gameManagerMaster.InventoryUIToggleEvent -= InventoryToggle;
        }
        private void Initialization()
        {
            gameManagerMaster = GetComponent<GameManagerMaster>();
            if (InventoryUI == null)
            {
                Debug.LogError("InventoryUI not found! by ToggleInventory class, gameobject: " + gameObject.name);
            }
        }
        public void InventoryToggle()
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }
}
