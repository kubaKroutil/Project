using Project.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField]
        private Transform inventoryPlayerParent;
        [SerializeField]
        private Transform inventoryUIParent;
        [SerializeField]
        private GameObject buttonPrefab;
        [SerializeField]
        private float timeToPlaceInHands = 0.3f;


        private PlayerController playerController;
        private readonly List<Transform> Inventory = new List<Transform>();
        public Transform CurrentItem { get; set; }
        public bool AreHandsEmpty => CurrentItem == null;
        public bool IsInventoryEmpty => Inventory.Count == 0;

        private void Initialization()
        {
            playerController = transform.root.GetComponent<PlayerController>();
        }
        private void OnEnable()
        {
            Initialization();
            UpdateInventoryAndUI();
            CheckIfHandsEmpty();
            playerController.InventoryChangedEvent += UpdateInventoryAndUI;
            playerController.InventoryChangedEvent += CheckIfHandsEmpty;
            playerController.HandsEmptyEvent += ClearHands;
        }
        private void OnDisable()
        {
            playerController.InventoryChangedEvent -= UpdateInventoryAndUI;
            playerController.InventoryChangedEvent -= CheckIfHandsEmpty;
            playerController.HandsEmptyEvent -= ClearHands;
        }
        private void UpdateInventoryAndUI()
        {
            int Counter = 0;
            Inventory.Clear();
            Inventory.TrimExcess();
            ClearInventoryUI();
            foreach (Transform transform in inventoryPlayerParent)
            {
                if (transform.CompareTag("Item"))
                {
                    //TODO:ActivateInventoryItem(Counter) not working
                    int index = Counter;
                    Inventory.Add(transform);
                    GameObject go = Instantiate(buttonPrefab) as GameObject;
                    go.GetComponentInChildren<Text>().text = transform.name;
                    go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
                    Debug.Log(Counter);
                    go.GetComponent<Button>().onClick.AddListener(delegate { playerController.GameManagerMaster.CallInventoryUIToggleEvent(); });
                    go.transform.SetParent(inventoryUIParent, false);
                    Counter++;
                }
            }
        }
        /// <summary>
        /// If hands are empty, eqip first item in inventory
        /// </summary>
        private void CheckIfHandsEmpty()
        {
            if (AreHandsEmpty && !IsInventoryEmpty)
            {
                StartCoroutine(PlaceItemsInHands(Inventory[0]));
            }
        }
        private void ClearHands()
        {
            CurrentItem = null;
        }
        private void ClearInventoryUI()
        {
            foreach (Transform transform in inventoryUIParent)
            {
                Destroy(transform.gameObject);
            }
        }
        public void ActivateInventoryItem(int itemIndex)
        {
            DeactivateAllItems();
            StartCoroutine(PlaceItemsInHands(Inventory[itemIndex]));
        }
        private void DeactivateAllItems()
        {
            foreach (Transform transform in inventoryPlayerParent)
            {
                if (transform.CompareTag(References.ItemTag))
                {
                    transform.gameObject.SetActive(false);
                }
            }
        }

        private IEnumerator PlaceItemsInHands(Transform _Item)
        {
            yield return new WaitForSeconds(timeToPlaceInHands);
            CurrentItem = _Item;
            CurrentItem.gameObject.SetActive(true);
        }
    }
}