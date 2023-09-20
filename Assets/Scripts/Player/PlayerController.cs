using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRK.Events;

namespace BRK.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float m_speed = 5f;
        private void OnEnable()
        {
            EventBusManager.OnPlayerHorizontalInput += Move;
        }

        private void OnDisable()
        {
            EventBusManager.OnPlayerHorizontalInput -= Move;
        }

        private void Move(float value)
        {
            transform.Translate(Vector3.right * value * m_speed * Time.deltaTime);
        }
    }
}