using BRK.Events;
using UnityEngine;
using BRK.Utilities;
using System.Collections;
using System.Collections.Generic;

namespace BRK.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private int m_currentScore = 0;
        private bool m_canRestart = false;

        private void OnEnable()
        {
            EventBusManager.OnBallHitBrick += AddScore;
            EventBusManager.OnVictory += EndGame;
            EventBusManager.OnPressRestart += TryRestart;
        }

        private void OnDisable()
        {
            EventBusManager.OnBallHitBrick -= AddScore;
            EventBusManager.OnVictory -= EndGame;
            EventBusManager.OnPressRestart -= TryRestart;
        }

        private void Start()
        {
            ResetStage();
        }

        private void AddScore(GameObject brick)
        {
            SetScore(m_currentScore + 1);
        }

        private void SetScore(int score)
        {
            m_currentScore = score;
            EventBusManager.RaiseChangeScore(m_currentScore);
        }

        private void ResetStage()
        {
            m_canRestart = false;
            SetScore(0);
            EventBusManager.ResetStage();
        }

        private void EndGame()
        {
            m_canRestart = true;
        }

        private void TryRestart()
        {
            if (m_canRestart)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}