using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRK.Events;

namespace BRK.Gameplay.Ball
{
    public class BallCollisionController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Brick"))
            {
                EventBusManager.RaiseBallHitBrick(other.gameObject);
            }
        }
    }
}