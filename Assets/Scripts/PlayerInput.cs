using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerController playerController;
        private void OnEnable()
        {
            Initialization();
        }
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                CheckWhatCursorHit();
            }
        }

        private void Initialization()
        {
            this.playerController = this.transform.root.GetComponent<PlayerController>();
        }
        private void CheckWhatCursorHit()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //playerController.CallMoveEvent(hit.point);
            }
        }
    }
}