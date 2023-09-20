using BRK.Events;
using UnityEngine;
using BRK.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace BRK.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        const int MAX_LIVES = 5;
        const int INITIAL_SCORE = 0;
        private int m_currentScore = INITIAL_SCORE;
        private bool m_canRestart = false;
        private int m_playerLives = MAX_LIVES;

        private void OnEnable()
        {
            EventBusManager.OnVictory += EndGame;
            EventBusManager.OnDefeat += EndGame;
            EventBusManager.OnBallHitBrick += AddScore;
            EventBusManager.OnPressRestart += TryRestart;
            EventBusManager.OnBallOutOfBounds += LoseLife;
        }

        private void OnDisable()
        {
            EventBusManager.OnVictory -= EndGame;
            EventBusManager.OnDefeat -= EndGame;
            EventBusManager.OnBallHitBrick -= AddScore;
            EventBusManager.OnPressRestart -= TryRestart;
            EventBusManager.OnBallOutOfBounds -= LoseLife;
        }

        private void Start() => ResetStage();

        private void AddScore(GameObject brick) => SetScore(m_currentScore + 1);

        private void LoseLife()
        {
            SetLives(m_playerLives - 1);
            if (m_playerLives <= 0)
            {
                EventBusManager.RaiseDefeat();
            }
        }

        private void SetScore(int score)
        {
            m_currentScore = score;
            EventBusManager.RaiseChangeScore(m_currentScore);
        }

        private void SetLives(int lives)
        {
            m_playerLives = lives;
            EventBusManager.RaiseChangeLives(m_playerLives);
        }

        private void ResetStage()
        {
            m_canRestart = false;
            SetScore(INITIAL_SCORE);
            SetLives(MAX_LIVES);
            EventBusManager.ResetStage();
        }

        private void EndGame() => m_canRestart = true;

        private void TryRestart()
        {
            if (m_canRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}