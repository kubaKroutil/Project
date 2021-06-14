using Project.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region DELEGATES
        public delegate void PlayerEventHandler();
        public event PlayerEventHandler InventoryChangedEvent;
        public event PlayerEventHandler HandsEmptyEvent;
        public event PlayerEventHandler AmmoChangedEvent;
        public event PlayerEventHandler PickItemEvent;

        public delegate void MoveEventHandler(Vector3 vector3);
        public event MoveEventHandler MoveEvent;

        public delegate void SetItemToPickHandler(Transform itemTransform);
        public event SetItemToPickHandler SetItemToPickEvent;

        public delegate void PlayerHealthEventHandler(int hitPointChange);
        public event PlayerHealthEventHandler PlayerHealthIncreaseEvent;
        public event PlayerHealthEventHandler PlayerHealthDecreaseEvent;
        #endregion
        [SerializeField]
        private float throwForce;
        public float ThrowForce { get { return throwForce; } }
        public GameManagerMaster GameManagerMaster { get; private set; }
        private void Awake()
        {
            GameManagerMaster = FindObjectOfType<GameManagerMaster>();
        }
        public void CallSetItemToPickEvent(Transform transform)
        {
            SetItemToPickEvent?.Invoke(transform);
        }
        public void CallMoveEvent(Vector3 _Vector3)
        {
            MoveEvent?.Invoke(_Vector3);
        }
        public void CallInventoryChangedEvent()
        {
            CallEvent(InventoryChangedEvent);
        }
        public void CallPickItemEvent()
        {
            CallEvent(PickItemEvent);
        }
        public void CallHandsEmptyEvent()
        {
            CallEvent(HandsEmptyEvent);
        }
        public void CallAmmoChangedEvent()
        {
            CallEvent(AmmoChangedEvent);
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