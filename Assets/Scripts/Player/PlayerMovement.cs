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
        private void Initialization()
        {
            this.playerController = this.GetComponent<PlayerController>();
            this.navMeshAgent = this.GetComponent<NavMeshAgent>();
            this.MovementState = MovementState.Idle;
        }
        private void Move(Vector3 hit)
        {
            this.navMeshAgent.SetDestination(hit);
            this.MovementState = MovementState.Move;
        }
    }
}