using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRK.Events;

namespace BRK.Gameplay.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float m_ballLowerBoundary = -5f;
        [SerializeField][Range(0f, 10f)] private float m_ballSpeed = 5f;
        [SerializeField] private Transform m_resetPosition;

        private bool m_isCaptured = false;

        private Rigidbody2D m_rigidbody;

        private void OnEnable()
        {
            EventBusManager.OnBallOutOfBounds += Capture;
            EventBusManager.OnResetStage += Capture;
            EventBusManager.OnReleaseBall += ReleaseBall;
        }

        private void OnDisable()
        {
            EventBusManager.OnBallOutOfBounds -= Capture;
            EventBusManager.OnResetStage -= Capture;
            EventBusManager.OnReleaseBall -= ReleaseBall;
        }

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_isCaptured = false;
        }

        private void Update()
        {
            if (transform.position.y < m_ballLowerBoundary)
            {
                EventBusManager.RaiseBallOutOfBounds();
            }
        }

        private void Capture()
        {
            if (!m_isCaptured)
            {
                m_rigidbody.velocity = Vector2.zero;
                m_rigidbody.isKinematic = true;
                transform.position = m_resetPosition.position;
                transform.SetParent(m_resetPosition);

                m_isCaptured = true;
            }
        }

        private void ReleaseBall()
        {
            if (m_isCaptured)
            {
                transform.SetParent(null);
                m_rigidbody.isKinematic = false;
                m_rigidbody.velocity = new Vector2(Random.Range(-1f, 1f), 1f).normalized * m_ballSpeed;

                m_isCaptured = false;
            }
        }

    }
}