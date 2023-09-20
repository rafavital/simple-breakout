using BRK.Events;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BRK.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        const string HORIZONTAL_AXIS = "Horizontal";

        private float m_horizontalInput;

        void Update()
        {
            CheckHorizontalInput();
        }

        private void CheckHorizontalInput()
        {
            m_horizontalInput = Input.GetAxis(HORIZONTAL_AXIS);
            EventBusManager.RaisePlayerHorizontalInput(m_horizontalInput);
        }
    }
}