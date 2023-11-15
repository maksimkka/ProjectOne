using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace Code.Score
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        private StringBuilder stringBuilder;
        private int currentScore;

        private void Awake()
        {
            stringBuilder = new StringBuilder();
            stringBuilder.Clear();
            IncreaseScore(0);
        }

        public void IncreaseScore(int value)
        {
            stringBuilder.Clear();
            currentScore += value;
            stringBuilder.Append("Score: ");
            stringBuilder.Append(currentScore);
            scoreText.text = stringBuilder.ToString();
        }
    }
}