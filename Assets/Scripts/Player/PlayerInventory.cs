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
        private Transform InventoryPlayerParent;
        [SerializeField]
        private Transform InventoryUIParent;
        [SerializeField]
        private GameObject ButtonPrefab;
        [SerializeField]
        private float TimeToPlaceInHands = 0.3f;

        private PlayerController PlayerController;
        private Transform CurrentItem;
        private int Counter;
        private List<Transform> Inventory = new List<Transform>();
        private void Initialization()
        {
            this.PlayerController = transform.root.GetComponent<PlayerController>();
        }
        private void OnEnable()
        {
            Initialization();
            UpdateInventoryAndUI();
            CheckIfHandsEmpty();
            this.PlayerController.InventoryChangedEvent += UpdateInventoryAndUI;
            this.PlayerController.InventoryChangedEvent += CheckIfHandsEmpty;
            this.PlayerController.HandsEmptyEvent += ClearHands;
        }
        private void OnDisable()
        {
            this.PlayerController.InventoryChangedEvent -= UpdateInventoryAndUI;
            this.PlayerController.InventoryChangedEvent -= CheckIfHandsEmpty;
            this.PlayerController.HandsEmptyEvent -= ClearHands;
        }
        private void UpdateInventoryAndUI()
        {
            this.Counter = 0;
            Inventory.Clear();
            Inventory.TrimExcess();
            ClearInventoryUI();
            foreach (Transform transform in this.InventoryPlayerParent)
            {
                if (transform.CompareTag("Item"))
                {
                    this.Inventory.Add(transform);
                    GameObject go = Instantiate(ButtonPrefab) as GameObject;
                    go.GetComponentInChildren<Text>().text = transform.name;
                    int index = this.Counter;
                    go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
                    go.GetComponent<Button>().onClick.AddListener(delegate { PlayerController.GameManagerMaster.CallInventoryUIToggleEvent(); });
                    go.transform.SetParent(this.InventoryUIParent, false);
                    Counter++;
                }
            }
        }
        /// <summary>
        /// If hands are empty, eqip first item in inventory
        /// </summary>
        private void CheckIfHandsEmpty()
        {
            if (CurrentItem == null && Inventory.Count > 0)
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
            foreach (Transform transform in this.InventoryUIParent)
            {
                Destroy(transform.gameObject);
            }
        }
        public void ActivateInventoryItem(int _Index)
        {
            DeactivateAllItems();
            StartCoroutine(PlaceItemsInHands(Inventory[_Index]));
        }
        private void DeactivateAllItems()
        {
            foreach (Transform transform in this.InventoryPlayerParent)
            {
                if (transform.CompareTag(References.ItemTag))
                {
                    transform.gameObject.SetActive(false);
                }
            }
        }
        IEnumerator PlaceItemsInHands(Transform _Item)
        {
            yield return new WaitForSeconds(TimeToPlaceInHands);
            CurrentItem = _Item;
            CurrentItem.gameObject.SetActive(true);
        }
    }
}