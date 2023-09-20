using UnityEngine;
using BRK.Utilities;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace BRK.Events
{
    public static class EventBusManager
    {
        public static UnityAction<float> OnPlayerHorizontalInput;
        public static UnityAction OnBallOutOfBounds;
        public static UnityAction<GameObject> OnBallHitBrick;
        public static UnityAction<int> OnGameStateChanged;
        public static UnityAction<int> OnChangeScore;
        public static UnityAction OnVictory;
        public static void RaisePlayerHorizontalInput(float value) => OnPlayerHorizontalInput?.Invoke(value);
        public static void RaiseBallOutOfBounds() => OnBallOutOfBounds?.Invoke();
        public static void RaiseBallHitBrick(GameObject brick) => OnBallHitBrick?.Invoke(brick);
        public static void RaiseVictory() => OnVictory?.Invoke();
        public static void RaiseGameStateChanged(int state) => OnGameStateChanged?.Invoke(state);
        public static void RaiseChangeScore(int score) => OnChangeScore?.Invoke(score);
    }
}