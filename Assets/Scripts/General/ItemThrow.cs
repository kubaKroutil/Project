using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General.Item
{
    public class ItemThrow : MonoBehaviour
    {
        private ItemController itemController;
        private Transform myTransform;
        private Rigidbody myRigidbody;
        private Vector3 throwDirection;
        [SerializeField]
        private bool canBeThrown = true;
        [SerializeField]
        private string throwButtonName;
        [SerializeField]
        private float throwForce = 100f;

        private void OnEnable()
        {
            Initialization();
        }
        private void Update()
        {
            if(canBeThrown)CheckForInput();
        }

        private void CheckForInput()
        {
            if (Input.GetButtonDown(throwButtonName) && myTransform.root.CompareTag(References.PlayerTag))
            {
                ThrowAction();
            }
        }
        private void ThrowAction()
        {
            throwDirection = myTransform.parent.forward;
            myTransform.parent = null;
            itemController.CallItemThrowEvent();
            HurtItem();
        }
        private void HurtItem()
        {
            myRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }

        private void Initialization()
        {
            this.itemController = this.GetComponent<ItemController>();
            this.myTransform = this.transform;
            this.myRigidbody = this.GetComponent<Rigidbody>();
        }
    }
}