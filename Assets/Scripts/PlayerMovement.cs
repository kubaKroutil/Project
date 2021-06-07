using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Player
{
    public enum MovementState
    {
        Idle, Move, MoveAndPick
    }
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerController playerController;
        private NavMeshAgent navMeshAgent;
        public MovementState MovementState { get; private set; }
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
            if (Physics.Raycast(ray, out RaycastHit hit))
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