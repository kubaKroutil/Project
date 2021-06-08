using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private PlayerController playerController;
        private NavMeshAgent navMeshAgent;
        private Animator animator;
        private void OnEnable()
        {
            this.Initialization();
        }
        private void OnDisable()
        {

        }
        private void Update()
        {
            UpdateAnimator();
        }
        private void Initialization()
        {
            this.playerController = this.GetComponent<PlayerController>();
            this.navMeshAgent = this.GetComponent<NavMeshAgent>();
            this.animator = this.GetComponent<Animator>();
        }
        private void UpdateAnimator()
        {
            Vector3 _Velocity = this.navMeshAgent.velocity;
            Vector3 _LocalVelocity = transform.InverseTransformDirection(_Velocity);
            float _Speed = _LocalVelocity.z;
            animator.SetFloat("speed", _Speed);
        }
    }
}