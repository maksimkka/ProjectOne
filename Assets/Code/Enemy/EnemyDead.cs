using System;
using Code.Constants;
using Code.Score;
using UnityEngine;

namespace Code.Enemy
{
    public class EnemyDead : MonoBehaviour
    {
        [SerializeField]
        private int value;

        private ScoreCounter scoreCounter;
        
        private void Awake()
        {
            scoreCounter = FindObjectOfType<ScoreCounter>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == Layers.Bullet)
            {
                scoreCounter.IncreaseScore(value);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}