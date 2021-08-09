using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General
{
    [System.Serializable]
    public enum EffectType
    {
        Poison, Slow
    }
    [System.Serializable]
    public abstract class EffectBase
    {
        public float Duration { get; protected set; }
        public EffectType Type { get; protected set; }
        public float Countdown { get; protected set; }
        public float CausedBy { get; protected set; }
        public bool Quit { get; protected set; }

        public EffectBase(float duration, EffectType type, float causedBy)
        {
            Duration = duration;
            Type = type;
            Countdown = Duration;
            CausedBy = causedBy;
            Quit = false;
            //StartCoroutine(DoEffect());
        }

        protected abstract IEnumerator DoEffect();

        protected IEnumerator Wait()
        {
            while (Countdown > 0)
            {
                Countdown -= Time.deltaTime;
                Debug.Log("We have waited for: " + Countdown + " seconds");
                if (Quit)
                {
                    //Quit function
                    yield break;
                }
                //Wait for a frame so that Unity doesn't freeze
                yield return null;
            }
        }
    }
}