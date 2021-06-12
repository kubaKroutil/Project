using Project.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemSetTransform : MonoBehaviour
    {
        [SerializeField]
        private Vector3 localPosition;
        private ItemController itemController;
        private void OnEnable()
        {
            Initialization();
            if (itemController.IsInInventory)
            {
                ResetTransform();
            }
            itemController.PickUpEvent += ResetTransform;
        }
        private void OnDisable()
        {
            itemController.PickUpEvent -= ResetTransform;
        }
        private void ResetTransform()
        {
            transform.localPosition = localPosition;
            transform.localRotation = Quaternion.identity;
        }
        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
        }
    }
}