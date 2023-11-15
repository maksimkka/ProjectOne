using Code.Animations;
using Code.Hero;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent navMeshAgent;
        [SerializeField]
        private Animator animator;
        
        private Transform targetMove;
        private GroundChecker groundChecker;
        
        private AnimationSwitcher animationSwitcher;
        private bool isHeroOnBase;

        private readonly int runAnimation = Animator.StringToHash("Running");
        private readonly int idleAnimation = Animator.StringToHash("DynIdle");

        private void Awake()
        {
            animationSwitcher = new AnimationSwitcher(animator);
            targetMove = FindObjectOfType<HeroMovement>().transform;
            groundChecker = FindObjectOfType<GroundChecker>();
        }

        private void OnEnable()
        {
            groundChecker.LeftBase += ChangeState;
            groundChecker.ReturnBase += ChangeState;
            ChangeState(groundChecker.IsHeroBase);
        }
        
        private void OnDisable()
        {
            groundChecker.LeftBase -= ChangeState;
            groundChecker.ReturnBase -= ChangeState;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if(isHeroOnBase) return;
            navMeshAgent.SetDestination(targetMove.position);
        }
        private void ChangeState(bool isHeroBase)
        {
            if (isHeroBase)
            {
                animationSwitcher.PlayAnimation(idleAnimation);
                isHeroOnBase = true;
                navMeshAgent.isStopped = true;
            }

            else
            {
                animationSwitcher.PlayAnimation(runAnimation);
                isHeroOnBase = false;
                navMeshAgent.isStopped = false;
            }
        }
    }
}