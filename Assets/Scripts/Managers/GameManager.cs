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
        private void Awake()
        {
            ChangeState(GameStates.Setup);
        }

        private void OnEnable()
        {
            EventBusManager.OnBallHitBrick += AddScore;
        }

        private void OnDisable()
        {
            EventBusManager.OnBallHitBrick -= AddScore;
        }

        private void ChangeState(GameStates newState)
        {
            CurrentState = newState;
            EventBusManager.RaiseGameStateChanged((int)newState);
        }

        private void AddScore(GameObject brick)
        {
            m_currentScore++;
            EventBusManager.RaiseChangeScore(m_currentScore);
        }
    }
}