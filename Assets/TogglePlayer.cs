using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    public class TogglePlayer : MonoBehaviour
    {
        [SerializeField]
        private GameObject Player = null;
        private GameManagerMaster gameManagerMaster;

        private void OnEnable()
        {
            Initialization();
            gameManagerMaster.MenuToggleEvent += TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
        }

        private void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
        }

        private void Initialization()
        {
            this.gameManagerMaster = this.GetComponent<GameManagerMaster>();
            if (Player == null)
            {
                Debug.LogError("Player not found! by TogglePlayer class, gameobject: " + this.gameObject.name);
            }
        }

        private void TogglePlayerController()
        {
            //TODO
        }
    }
}
