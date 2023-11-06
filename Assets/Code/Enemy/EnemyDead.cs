using System;
using Code.Constants;
using UnityEngine;

namespace Code.Enemy
{
    public class EnemyDead : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == Layers.Bullet)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}