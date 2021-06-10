using Project.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemSetTransform : MonoBehaviour
    {
        private ItemController itemController;
        public Vector3 localPosition;
        private void OnEnable()
        {
            this.Initialization();
            ResetTransform();
            itemController.ItemPickUpEvent += ResetTransform;
        }
        private void OnDisable()
        {
            itemController.ItemPickUpEvent -= ResetTransform;
        }
        private void ResetTransform()
        {
            if (transform.root.CompareTag(References.PlayerTag))
            {
                this.transform.localPosition = this.localPosition;
                this.transform.localRotation = Quaternion.identity;
            }
        }
        private void Initialization()
        {
            this.itemController = GetComponent<ItemController>();
        }
    }
} 