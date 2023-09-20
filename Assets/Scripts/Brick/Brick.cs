using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRK.Events;


namespace BRK.Gameplay.Brick
{
    public class Brick : MonoBehaviour
    {
        public static List<Brick> AllBricks = new List<Brick>();
        private void OnEnable()
        {
            EventBusManager.OnBallHitBrick += DestroyBrick;
            AllBricks.Add(this);
        }

        private void OnDisable()
        {
            EventBusManager.OnBallHitBrick -= DestroyBrick;
            AllBricks.Remove(this);
            CheckVictory();
        }

        private void DestroyBrick(GameObject brick)
        {
            if (brick != gameObject)
            {
                return;
            }

            Destroy(gameObject);
        }

        private void CheckVictory()
        {
            if (AllBricks.Count == 0)
            {
                EventBusManager.RaiseVictory();
            }
        }
    }
}