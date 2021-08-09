using UnityEngine;
using UnityEngine.AI;

namespace Project.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private NavMeshAgent myNavMeshAgent;
        private Animator myAnimator;
        private void OnEnable()
        {
            Initialization();
        }
        private void Update()
        {
            UpdateAnimator();
        }
        private void Initialization()
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
            myAnimator = GetComponent<Animator>();
        }
        private void UpdateAnimator()
        {
            Vector3 _LocalVelocity = transform.InverseTransformDirection(myNavMeshAgent.velocity);
            myAnimator.SetFloat("speed", _LocalVelocity.z);
        }
    }
}