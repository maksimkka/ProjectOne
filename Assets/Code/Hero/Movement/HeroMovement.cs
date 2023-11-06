using System;
using Code.Animations;
using UnityEngine;

namespace Code.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField]
        private float MoveSpeed;

        [SerializeField]
        private float RotationSpeed;

        [SerializeField]
        private Animator Animator;
        
        private AnimationSwitcher animationSwitcher;

        private readonly int runAnimation = Animator.StringToHash("Running");
        private readonly int dynIdleAnimation = Animator.StringToHash("DynIdle");

        private void Awake()
        {
            animationSwitcher = new AnimationSwitcher(Animator);
        }

        void Update()
        {
            HeroMove();
            HeroRotate();
        }

        private void HeroMove()
        {
            var move = Input.GetAxis("Vertical");

            PlayRunAnimation(move);
            if (move == 0) return;

        
            transform.Translate(new Vector3(0f, 0f, move * MoveSpeed * Time.deltaTime));
        }

        private void HeroRotate()
        {
            var rotate = Input.GetAxis("Horizontal");
            if (rotate == 0) return;

            transform.Rotate(new Vector3(0f, rotate * RotationSpeed * Time.deltaTime, 0f));
        }

        private void PlayRunAnimation(float move)
        {
            if (move != 0)
            {
                animationSwitcher.PlayAnimation(runAnimation);
            }

            else
            {
                animationSwitcher.PlayAnimation(dynIdleAnimation);
            }
        }
    }
}