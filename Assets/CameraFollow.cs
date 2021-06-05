using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform Target;
        private void LateUpdate()
        {
            transform.position = Target.position;
        }
    }
}