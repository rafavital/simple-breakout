using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRK.Events;

namespace BRK.Gameplay.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float m_ballLowerBoundary = -5f;
        [SerializeField] private Transform m_resetPosition;

        private Rigidbody2D m_rigidbody;

        private void OnEnable()
        {
            EventBusManager.OnBallOutOfBounds += ResetBall;
        }

        private void OnDisable()
        {
            EventBusManager.OnBallOutOfBounds -= ResetBall;
        }

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (transform.position.y < m_ballLowerBoundary)
            {
                EventBusManager.RaiseBallOutOfBounds();
            }
        }

        private void ResetBall()
        {
            m_rigidbody.position = m_resetPosition.position;
            m_rigidbody.velocity = Vector2.zero;
        }

    }
}