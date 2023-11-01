using Code.Constants;
using UnityEngine;

namespace Code.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float LifeTime;

        private float currentLifeTime;

        private void Update()
        {
            currentLifeTime += Time.deltaTime;

            if (currentLifeTime >= LifeTime)
            {
                currentLifeTime = 0;
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == Layers.Ground)
            {
                Destroy(gameObject);
            }
        }
    }
}