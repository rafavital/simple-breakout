using UnityEngine;
using BRK.Events;
using System.Collections;
using System.Collections.Generic;

namespace BRK.UI
{
    public class WinScreenController : MonoBehaviour
    {
        private CanvasGroup m_canvasGroup;


        private void OnEnable()
        {
            EventBusManager.OnVictory += Show;
            EventBusManager.OnResetStage += Hide;
        }

        private void OnDisable()
        {
            EventBusManager.OnVictory -= Show;
            EventBusManager.OnResetStage -= Hide;
        }

        private void Awake()
        {
            m_canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Hide() => m_canvasGroup.alpha = 0;

        private void Show() => m_canvasGroup.alpha = 1;
    }
}