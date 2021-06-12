﻿using UnityEngine;

namespace Project.General.Item
{
    public class ItemDrop : MonoBehaviour
    {
        private ItemController itemController;
        private Rigidbody myRigidbody;
        private readonly float dropForce = 1f;

        private void OnEnable()
        {
            Initialization();
            itemController.DropEvent += DropItem;
        }
        private void OnDisable()
        {
            itemController.DropEvent -= DropItem;
        }
        private void DropItem()
        {
            myRigidbody.AddForce(transform.forward * dropForce, ForceMode.Impulse);
        }

        private void Initialization()
        {
            itemController = GetComponent<ItemController>();
            myRigidbody = GetComponent<Rigidbody>();
        }
    }
}