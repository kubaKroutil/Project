using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General
{
    [System.Serializable]
    public enum EffectType
    {
        Haste, Slow
    }
    [System.Serializable]
    public abstract class EffectBase
    {
        public float Duration { get; protected set; }
        public EffectType Type { get; protected set; }
        public float Countdown { get; protected set; }
        public string CausedBy { get; protected set; }
        public bool Quit { get; protected set; }
        public List<EffectBase> EffectList { get; protected set; }

        public EffectBase(EffectType type, List<EffectBase> effectList, float duration, string causedBy)
        {
            Duration = duration;
            Type = type;
            Countdown = Duration;
            CausedBy = causedBy;
            Quit = false;
            EffectList = effectList;
        }
        public IEnumerator StartEffect()
        {
            OnEffectStart();
            yield return Wait();
            OnEffectEnd();
            yield break;
        }
        public void EndEffect()
        {
            Quit = false;
        }
        protected abstract void OnEffectStart();
        protected virtual void OnEffectEnd()
        {
            EffectList.Remove(this);
        }
        protected IEnumerator Wait()
        {
            while (Countdown > 0)
            {
                Countdown -= Time.deltaTime;
                //Debug.Log(Countdown);
                if (Quit)
                {
                    yield break;
                }
                yield return null;
            }
        }
    }
}