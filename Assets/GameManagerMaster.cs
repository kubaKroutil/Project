using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    public class GameManagerMaster : MonoBehaviour
    {
        public delegate void GameManagerEventHandler();
        public event GameManagerEventHandler MenuToggleEvent;
        public event GameManagerEventHandler InventoryUIToggleEvent;
        public event GameManagerEventHandler RestartLevelEvent;
        public event GameManagerEventHandler GoToMenuSceneEvent;
        public event GameManagerEventHandler GameOverEvent;

        public bool isGameOver = false;
        public bool isInventoryUIOn = false;
        public bool isMenuOn = false;

        public void CallMenuToggleEvent()
        {
            CallEvent(MenuToggleEvent);
        }

        public void CallInventoryUIToggleEvent()
        {
            CallEvent(InventoryUIToggleEvent);
        }

        public void CallRestartLevelEvent()
        {
            CallEvent(RestartLevelEvent);
        }

        public void CallGoToMenuSceneEvent()
        {
            CallEvent(GoToMenuSceneEvent);
        }

        public void CallGameOverEvent()
        {
            CallEvent(GameOverEvent);
        }

        private void CallEvent(GameManagerEventHandler eventToCall)
        {
            eventToCall?.Invoke();
        }
    }
}
