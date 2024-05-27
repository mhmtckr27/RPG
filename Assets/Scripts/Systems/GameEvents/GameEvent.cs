using System.Collections.Generic;
using UnityEngine;

namespace RPG.Systems.GameEvents
{
    [CreateAssetMenu(menuName = "RPG/Scriptable Objects/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly HashSet<GameEventListener> _eventListeners = new();

        public void Register(GameEventListener eventListener)
        {
            _eventListeners.Add(eventListener);
        }

        public void Unregister(GameEventListener eventListener)
        {
            _eventListeners.Remove(eventListener);
        }

        public void Invoke()
        {
            foreach (var gameEventListener in _eventListeners)
            {
                gameEventListener.RaiseEvent();
            }
        }
    }
}