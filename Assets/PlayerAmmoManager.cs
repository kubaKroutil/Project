using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Player
{
    public class PlayerAmmoManager : MonoBehaviour
    {
        private PlayerController playerController;

        public List<AmmoType> AmmoTypes = new List<AmmoType>();

        private void OnEnable()
        {
            Initialization();
            playerController.PickUpAmmoEvent += PickUpAmmo;
        }
        private void OnDisable()
        {
            playerController.PickUpAmmoEvent -= PickUpAmmo;
        }
        private void Initialization()
        {
            this.playerController = this.transform.root.GetComponent<PlayerController>();
        }
        private void PickUpAmmo(string _AmmoName, int _Quantity)
        {
            //TODO: CHECK IF YOU ALREADY CARRY AMMO AND ADD IT TO LIST
            playerController.CallAmmoChangedEvent();
        }

        
    }
    [System.Serializable]
    public class AmmoType
    {
        public string AmmoName;
        public int Quantity;
        public AmmoType(string _AmmoName, int _Quantity)
        {
            this.AmmoName = _AmmoName;
            this.Quantity = _Quantity;
        }
    }
}