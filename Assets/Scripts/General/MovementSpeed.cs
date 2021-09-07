using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General
{
    public class MovementSpeed : MonoBehaviour
    {
        public float MaxSpeed { get; private set; }
        public float MinSpeed { get; private set; }
        public float CurrentSpeed { get; private set; }
        public MovementSpeed(float currentSpeed, float maxSpeed, float minSpeed):this(currentSpeed, maxSpeed)
        {
            MinSpeed = minSpeed;
        }
        public MovementSpeed(float currentSpeed, float maxSpeed)
        {
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
            MinSpeed = 0;
        }
        public void SetSpeed(float speed)
        {
            CurrentSpeed = Mathf.Clamp(CurrentSpeed + speed, MinSpeed, MaxSpeed);
        }
    }
}