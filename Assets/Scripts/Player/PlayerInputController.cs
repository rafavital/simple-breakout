using BRK.Events;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BRK.Gameplay.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        const string HORIZONTAL_AXIS = "Horizontal";
        const KeyCode RELEASE_KEY = KeyCode.Space;

        private float m_horizontalInput;

        void Update()
        {
            CheckReleaseKey();
            CheckHorizontalInput();
        }

        private void CheckHorizontalInput()
        {
            m_horizontalInput = Input.GetAxis(HORIZONTAL_AXIS);
            EventBusManager.RaisePlayerHorizontalInput(m_horizontalInput);
        }

        private void CheckReleaseKey()
        {
            if (Input.GetKeyDown(RELEASE_KEY))
            {
                EventBusManager.RaiseReleaseBall();
            }
        }
    }
}