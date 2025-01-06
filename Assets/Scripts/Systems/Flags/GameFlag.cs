using System;
using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(menuName = "RPG/Scriptable Objects/Flags/Game", fileName = "New Game Flag")]
    public class GameFlag : ScriptableObject
    {
        public static event Action AnyChanged; 
        
        [field: SerializeField] public bool Value { get; private set; }

        private void OnEnable() => Value = default;

        public void Set(bool value)
        {
            Value = value;
            AnyChanged?.Invoke();
        }
    }
}
