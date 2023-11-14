using System.Threading;
using UnityEngine;

namespace Code.Animations
{
    public class AnimationSwitcher
    {
        private readonly Animator _animator;
        private int _hashCodeCurrentPlayedAnimation;
        public AnimationSwitcher(Animator animator)
        {
            _animator = animator;
        }

        public void PlayAnimation(int hashAnimation)
        {
            if(_hashCodeCurrentPlayedAnimation == hashAnimation) return;
            _hashCodeCurrentPlayedAnimation = hashAnimation;

            ResetAllTriggers(_animator);
            _animator.SetTrigger(hashAnimation);
        }

        public void GetTimeAnimation(int hashFirstAnimation)
        {
            // PlayAnimation(hashFirstAnimation);
            // await UniTask.DelayFrame(1);
            //
            // while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            // {
            //     await UniTask.Yield(cancellationToken: _tokenSources.Token);
            // }

            //PlayAnimation(hashFirstAnimation);
        }
        
        
        private void ResetAllTriggers(Animator animator)
        {
            var parameters = animator.parameters;
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                if (parameters[i].type == AnimatorControllerParameterType.Trigger)
                {
                    animator.ResetTrigger(parameters[i].name);
                }
            }
        }
    }
}