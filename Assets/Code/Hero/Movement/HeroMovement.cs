using System;
using Code.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField]
        private float MoveSpeed;
        [SerializeField]
        public float sensitivity;
        [SerializeField]
        public float smoothing;
        [SerializeField]
        private Animator Animator;

        private Controls controls;
        
        private AnimationSwitcher animationSwitcher;

        private readonly int runAnimation = Animator.StringToHash("Running");
        private readonly int dynIdleAnimation = Animator.StringToHash("DynIdle");
        
        private Vector2 mouseLook;
        private Vector2 smoothV;
        private bool isMove;

        private void Awake()
        {
            animationSwitcher = new AnimationSwitcher(Animator);
            controls = new Controls();
            controls.Move.Enable();
            controls.Rotate.Enable();
        }

		private void OnEnable()
		{
            controls.Rotate.RotateAround.performed += HeroRotate;
            controls.Move.Movement.performed += HeroMove;
        }

		private void OnDisable()
        {
            controls.Rotate.RotateAround.Disable();
            controls.Move.Movement.Disable();
        }

		void Update()
        {
            if(Time.timeScale == 0) return;
            PlayRunAnimation();
        }

        private void HeroMove(InputAction.CallbackContext context)
        {
            var move = context.ReadValue<Vector2>();
            isMove = move.x != 0 || move.y != 0;
            
            transform.Translate(new Vector3(move.x * MoveSpeed * Time.deltaTime,
                0f,
                move.y * MoveSpeed * Time.deltaTime));
        }


        private void HeroRotate(InputAction.CallbackContext context)
        {
            if (Time.timeScale == 0) return;
            var rotate = context.ReadValue<Vector2>();
            var mouseDelta = new Vector2(rotate.x, rotate.y);

            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
            mouseLook += smoothV;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

            //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            transform.localRotation = Quaternion.AngleAxis(mouseLook.x, transform.up);
        }

        private void PlayRunAnimation()
        {
            if (isMove)
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