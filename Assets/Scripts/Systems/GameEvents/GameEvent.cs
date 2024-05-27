using System.Collections.Generic;
using UnityEngine;

namespace RPG.Systems.GameEvents
{
    [CreateAssetMenu(menuName = "RPG/Scriptable Objects/Game Event")]
    public class GameEvent : ScriptableObject
    {
        [SerializeField] private string eventName;
        
        private static HashSet<GameEvent> _listeningEvents = new();
        private readonly HashSet<GameEventListener> _eventListeners = new();

        public void Register(GameEventListener eventListener)
        {
            _eventListeners.Add(eventListener);
            _listeningEvents.Add(this);
        }

        public void Unregister(GameEventListener eventListener)
        {
            _eventListeners.Remove(eventListener);
            
            if(_eventListeners.Count == 0)
                _listeningEvents.Remove(this);
        }

        private void Invoke()
        {
            foreach (var gameEventListener in _eventListeners)
            {
                gameEventListener.RaiseEvent();
            }
        }

        public static void RaiseEvent(string eventName)
        {
            foreach (var listeningEvent in _listeningEvents)
            {
                if(listeningEvent.eventName == eventName)
                    listeningEvent.Invoke();
            }
        }
    }
}