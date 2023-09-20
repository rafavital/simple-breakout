using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRK.Events;

public class LoseScreenController : MonoBehaviour
{
    private CanvasGroup m_canvasGroup;

    private void OnEnable()
    {
        EventBusManager.OnDefeat += Show;
        EventBusManager.OnResetStage += Hide;
    }

    private void OnDisable()
    {
        EventBusManager.OnDefeat -= Show;
        EventBusManager.OnResetStage -= Hide;
    }

    private void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Hide() => m_canvasGroup.alpha = 0;

    private void Show() => m_canvasGroup.alpha = 1;
}
