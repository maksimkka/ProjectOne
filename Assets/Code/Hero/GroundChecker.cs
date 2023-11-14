using System;
using Code.Constants;
using Code.Logger;
using UnityEngine;

namespace Code.Animations
{
    public class GroundChecker : MonoBehaviour
    {
        public event Action<bool> LeftBase;
        public event Action<bool> ReturnBase;
        public bool IsHeroBase { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == Layers.BaseGround)
            {
                IsHeroBase = true;
                $"4444444444444444444".Colored(Color.yellow).Log();
                ReturnBase?.Invoke(IsHeroBase);
            }

            else if (other.gameObject.layer == Layers.Ground)
            {
                IsHeroBase = false;
                $"555555555555555555".Colored(Color.yellow).Log();
                LeftBase?.Invoke(IsHeroBase);
            }
        }
    }
}