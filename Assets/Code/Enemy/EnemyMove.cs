using System;
using Code.Animations;
using Code.Hero;
using Code.Main;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent NavMesh;
        
        private Transform targetMove;
        
        [SerializeField]
        private Animator Animator;
        
        private AnimationSwitcher animationSwitcher;

        private readonly int runAnimation = Animator.StringToHash("Running");

        private void Awake()
        {
            animationSwitcher = new AnimationSwitcher(Animator);
            targetMove = FindObjectOfType<HeroMovement>().transform;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            NavMesh.SetDestination(targetMove.transform.position);
            animationSwitcher.PlayAnimation(runAnimation);
        }
    }
}