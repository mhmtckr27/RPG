using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(menuName = "RPG/Scriptable Objects/Flags/Game", fileName = "New Game Flag")]
    public class GameFlag : ScriptableObject
    {
        [field: SerializeField] public bool Value { get; private set; }

        private void OnEnable() => Value = default;
    }
}
