using System;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.Systems.GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private UnityEvent @event;

        private void Awake()
        {
            gameEvent.Register(this);
        }

        private void OnDestroy()
        {
            gameEvent.Unregister(this);
        }

        public void RaiseEvent()
        {
            @event.Invoke();
        }
    }
}