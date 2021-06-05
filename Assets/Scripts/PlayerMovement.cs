using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerController playerController;
        private NavMeshAgent navMeshAgent;
        private void OnEnable()
        {
            this.Initialization();
            playerController.MoveEvent += Move;
        }
        private void OnDisable()
        {
            playerController.MoveEvent -= Move;
        }
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }

        }

        private void Initialization()
        {
            this.playerController = this.GetComponent<PlayerController>();
            this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        }
        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                playerController.CallMoveEvent(hit.point);
            }
        }

        private void Move(Vector3 hit)
        {
            this.navMeshAgent.SetDestination(hit);
        }
    }
}