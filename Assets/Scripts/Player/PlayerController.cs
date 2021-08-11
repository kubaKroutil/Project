using Project.Core;
using Project.General;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region DELEGATES SETUP
        public delegate void PlayerEventHandler();
        public event PlayerEventHandler InventoryChangedEvent;
        public event PlayerEventHandler HandsEmptyEvent;
        public event PlayerEventHandler AmmoChangedEvent;
        public event PlayerEventHandler PickItemEvent;

        public delegate void MoveEventHandler(Vector3 vector3);
        public event MoveEventHandler MoveEvent;

        public delegate void SetItemToPickHandler(Transform itemTransform);
        public event SetItemToPickHandler SetItemToPickEvent;

        public delegate void PlayerHealthEventHandler(float hitPointChange);
        public event PlayerHealthEventHandler PlayerHealthIncreaseEvent;
        public event PlayerHealthEventHandler PlayerHealthDecreaseEvent;
        #endregion
        [SerializeField]
        private float throwForce;
        public float ThrowForce { get { return throwForce; } }
        public GameManagerMaster GameManagerMaster { get; private set; }
        [SerializeField]
        private List<EffectBase> Effects;
        #region UNITY METHODS
        private void Awake()
        {
            Effects = new List<EffectBase>();
            GameManagerMaster = FindObjectOfType<GameManagerMaster>();
        }
        private void OnGUI()
        {
            //Debug.Log(Screen.height + "=" + Screen.height + " adsa " + Input.mousePosition.x + " - " + Input.mousePosition.y);
            if (Effects.Count > 0)
            {
                string EffectsLabel = "Effects:";
                foreach (EffectBase effect in Effects)
                {
                    EffectsLabel += "\n" + effect.Type + " " + (int)effect.Countdown + " " + effect.CausedBy;
                }
                GUI.Label(new Rect(5, Screen.height - 300, 100, 200), EffectsLabel);
            }
        }
        #endregion
        public void AddEffect(EffectBase effectBase)
        {
            Effects.Add(effectBase);
            StartCoroutine(effectBase.StartEffect());
        }
        #region DELEGATES CALL
        public void CallSetItemToPickEvent(Transform transform)
        {
            SetItemToPickEvent?.Invoke(transform);
        }
        public void CallMoveEvent(Vector3 _Vector3)
        {
            MoveEvent?.Invoke(_Vector3);
            //AddEffect(new EffectSlow(Effects, 2, "aaa", GetComponent<NavMeshAgent>()));
        }
        public void CallInventoryChangedEvent()
        {
            InventoryChangedEvent?.Invoke();
        }
        public void CallPickItemEvent()
        {
            PickItemEvent?.Invoke();
        }
        public void CallHandsEmptyEvent()
        {
            HandsEmptyEvent?.Invoke();
        }
        public void CallAmmoChangedEvent()
        {
            AmmoChangedEvent?.Invoke();
        }
        public void CallPlayerHealthIncreaseEvent(float _Heal)
        {
            PlayerHealthIncreaseEvent?.Invoke(_Heal);
        }
        public void CallPlayerHealthDecreaseEvent(float _Damage)
        {
            PlayerHealthDecreaseEvent?.Invoke(_Damage);
        }
        #endregion


    }
}