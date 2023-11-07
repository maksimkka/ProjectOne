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
        public float sensitivity;
        [SerializeField]
        public float smoothing;
        [SerializeField]
        private Animator Animator;
        
        private AnimationSwitcher animationSwitcher;

        private readonly int runAnimation = Animator.StringToHash("Running");
        private readonly int dynIdleAnimation = Animator.StringToHash("DynIdle");
        
        private Vector2 mouseLook;
        private Vector2 smoothV;
        private bool isMoveVertical;
        private bool isMoveHorizontal;

        private void Awake()
        {
            animationSwitcher = new AnimationSwitcher(Animator);
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            HeroMove();
            HeroMoveHorizontal();
            HeroRotate();
            PlayRunAnimation();
        }

        private void HeroMove()
        {
            var move = Input.GetAxis("Vertical");
            isMoveVertical = false;
            if (move == 0) return;
            
            transform.Translate(new Vector3(0f, 0f, move * MoveSpeed * Time.deltaTime));
            isMoveVertical = true;
        }

        private void HeroMoveHorizontal()
        {
            var move = Input.GetAxis("Horizontal");
            isMoveHorizontal = false;
            PlayRunAnimation();
            if (move == 0) return;
            isMoveHorizontal = true;
            transform.Translate(new Vector3(move * MoveSpeed * Time.deltaTime, 0f, 0));
        }

        private void HeroRotate()
        {
            var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

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
            if (isMoveVertical || isMoveHorizontal)
            {
                animationSwitcher.PlayAnimation(runAnimation);
            }

            else if(!isMoveVertical && !isMoveHorizontal)
            {
                animationSwitcher.PlayAnimation(dynIdleAnimation);
            }
        }
    }
}