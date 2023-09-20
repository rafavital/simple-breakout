using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRK.Events;
using BRK.Utilities;

namespace BRK.Managers
{
    public enum GameStates
    {
        Setup = 0,
        Playing,
        Paused,
        GameOver,
        Victory
    }
    public class GameManager : Singleton<GameManager>
    {
        public static GameStates CurrentState;
        private int m_currentScore = 0;

        private void OnEnable()
        {
            EventBusManager.OnBallHitBrick += AddScore;
        }

        private void OnDisable()
        {
            EventBusManager.OnBallHitBrick -= AddScore;
        }

        private void Start()
        {
            ResetStage();
        }

        private void ChangeState(GameStates newState)
        {
            CurrentState = newState;
            EventBusManager.RaiseGameStateChanged((int)newState);
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
            SetScore(0);
            EventBusManager.ResetStage();
        }
    }
}