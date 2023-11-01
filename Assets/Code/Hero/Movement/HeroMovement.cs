using UnityEngine;

namespace Code.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField]
        private float MoveSpeed;

        [SerializeField]
        private float RotationSpeed;

        void Update()
        {
            HeroMove();
            HeroRotate();
        }

        private void HeroMove()
        {
            var move = Input.GetAxis("Vertical");

            if (move == 0) return;
        
            transform.Translate(new Vector3(0f, 0f, move * MoveSpeed * Time.deltaTime));
        }

        private void HeroRotate()
        {
            var rotate = Input.GetAxis("Horizontal");
            if (rotate == 0) return;

            transform.Rotate(new Vector3(0f, rotate * RotationSpeed * Time.deltaTime, 0f));
        }
    }
}