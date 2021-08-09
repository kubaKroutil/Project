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
            Initialization();
            playerController.MoveEvent += Move;
        }
        private void OnDisable()
        {
            playerController.MoveEvent -= Move;
        }
        private void Initialization()
        {
            playerController = GetComponent<PlayerController>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Move(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
        }
    }
}