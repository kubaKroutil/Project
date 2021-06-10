using Project.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemDrop : MonoBehaviour
    {
        private ItemController itemController;
        private Transform myTransform;
        private Rigidbody myRigidbody;
        private Vector3 throwDirection;
        [SerializeField]
        private string dropButtonName;
        private readonly float dropForce = 1f;

        private void OnEnable()
        {
            Initialization();
        }   
        private void Update()
        {
            CheckForInput();
        }

        private void CheckForInput()
        {
            if (Input.GetButtonDown(dropButtonName) && myTransform.root.CompareTag(References.PlayerTag)
                && Time.deltaTime > 0)
            {
                DropItemAction();
            }
        }
        private void DropItemAction()
        {
            throwDirection = myTransform.parent.forward;
            myTransform.parent = null;
            itemController.CallItemThrowEvent();
            DropItem();
        }
        private void DropItem()
        {
            myRigidbody.AddForce(throwDirection * dropForce, ForceMode.Impulse);
        }

        private void Initialization()
        {
            this.itemController = this.GetComponent<ItemController>();
            this.myTransform = this.transform;
            this.myRigidbody = this.GetComponent<Rigidbody>();
        }
    }
}