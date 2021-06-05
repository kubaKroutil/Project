using Project.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Player
{
public class PlayerController : MonoBehaviour
{
        public delegate void PlayerEventHandler();
        public event PlayerEventHandler InventoryChangedEvent;
        public event PlayerEventHandler HandsEmptyEvent;
        public event PlayerEventHandler AmmoChangedEvent;

        public delegate void MoveEventHandler(Vector3 _Vector3);
        public event MoveEventHandler MoveEvent;

        public delegate void AmmoEventHandler(string _AmmoType, int _Quantity);
        public event AmmoEventHandler PickUpAmmoEvent;

        public delegate void PlayerHealthEventHandler(int _HealthChange);
        public event PlayerHealthEventHandler PlayerHealthIncreaseEvent;
        public event PlayerHealthEventHandler PlayerHealthDecreaseEvent;

        public GameManagerMaster GameManagerMaster { get; set; }
        private void Awake()
        {
            this.GameManagerMaster = GameObject.FindObjectOfType<GameManagerMaster>();
        }
        public void CallMoveEvent(Vector3 _Vector3)
        {
            MoveEvent?.Invoke(_Vector3);
        }
        public void CallInventoryChangedEvent()
        {
            CallEvent(InventoryChangedEvent);
        }
        public void CallHandsEmptyEvent()
        {
            CallEvent(HandsEmptyEvent);
        }
        public void CallAmmoChangedEvent()
        {
            CallEvent(AmmoChangedEvent);
        }
        public void CallPickUpAmmoEvent(string _AmmoType, int _Quantity)
        {
            PickUpAmmoEvent?.Invoke(_AmmoType, _Quantity);
        }
        public void CallPlayerHealthIncreaseEvent(int _Hitpoints)
        {
            PlayerHealthIncreaseEvent?.Invoke(_Hitpoints);
        }
        public void CallPlayerHealthDecreaseEvent(int _Damage)
        {
            PlayerHealthDecreaseEvent?.Invoke(_Damage);
        }

        private void CallEvent(PlayerEventHandler eventToCall)
        {
            eventToCall?.Invoke();
        }
    }
}