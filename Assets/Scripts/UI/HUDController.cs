using TMPro;
using BRK.Events;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BRK.UI.HUD
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private TextMeshProUGUI m_livesText;
        private void OnEnable()
        {
            EventBusManager.OnChangeScore += UpdateScore;
            EventBusManager.OnChangeLives += UpdateLives;
        }

        private void OnDisable()
        {
            EventBusManager.OnChangeScore -= UpdateScore;
            EventBusManager.OnChangeLives -= UpdateLives;
        }

        private void UpdateScore(int score) => m_scoreText.text = $"{score.ToString()}";
        private void UpdateLives(int lives) => m_livesText.text = $"LIVES: {lives.ToString()}";
    }
}