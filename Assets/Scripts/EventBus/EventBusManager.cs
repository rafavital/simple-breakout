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
        public static void RaisePlayerHorizontalInput(float value) => OnPlayerHorizontalInput?.Invoke(value);
    }
}