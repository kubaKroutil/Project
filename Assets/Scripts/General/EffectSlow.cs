using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project.General
{
    public class EffectSlow : EffectBase
    {
        public NavMeshAgent NavMeshAgent { get; protected set; }

        public EffectSlow(List<EffectBase> effectList, float duration, string causedBy, NavMeshAgent navMeshAgent) : base(EffectType.Slow, effectList, duration, causedBy)
        {
            NavMeshAgent = navMeshAgent;
            Debug.Log("vytvoreno");
        }

        protected override void OnEffectStart()
        {
            Debug.Log("start");
            NavMeshAgent.speed = 2;
        }
        protected override void OnEffectEnd()
        {
            NavMeshAgent.speed = 5.66f;
            base.OnEffectEnd(); 
        }
    }
}