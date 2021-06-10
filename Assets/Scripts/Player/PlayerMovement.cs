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
            this.playerController.MoveEvent += Move;
        }
        private void OnDisable()
        {
            this.playerController.MoveEvent -= Move;
        }
        private void Initialization()
        {
            this.playerController = this.GetComponent<PlayerController>();
            this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        }
        private void Move(Vector3 hit)
        {
            this.navMeshAgent.SetDestination(hit);
        }
    }
}