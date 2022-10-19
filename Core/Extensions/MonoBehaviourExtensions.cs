using System;

namespace UnityEngine
{
    public static class MonoBehaviourExtensions
    {
        public static void LogEvent(this MonoBehaviour behaviour, Type caller, string eventName, string message = null)
        {
            string msg = string.IsNullOrWhiteSpace(message) ? "" : ": " + message;
            Debug.LogFormat("{0}: [{4}] called on {1}'s {2} at {3}{5}",
                 Time.frameCount,
                 behaviour.name,
                 caller.GetType().Name,
                 Time.time,
                 eventName,
                 msg);
        }
    }
}