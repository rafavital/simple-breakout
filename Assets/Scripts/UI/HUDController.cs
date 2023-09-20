using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRK.Events;
using TMPro;

namespace BRK.UI.HUD
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        private void OnEnable()
        {
            EventBusManager.OnChangeScore += UpdateScore;
        }

        private void OnDisable()
        {
            EventBusManager.OnChangeScore -= UpdateScore;
        }

        private void UpdateScore(int score)
        {
            m_scoreText.text = $"{score.ToString()}";
        }
    }
}