#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG
{
    public class GameFlagManager : MonoBehaviour
    {
        public static GameFlagManager Instance;
        
        [SerializeField] private List<GameFlag> allFlags;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }

#if UNITY_EDITOR
        [ContextMenu("Collect all game flags")]
        private void CollectAllFlags()
        {
            allFlags = new List<GameFlag>();
            var flagGuids = AssetDatabase.FindAssets("t:GameFlag");
            
            foreach (var flagGuid in flagGuids)
            {
                var path = AssetDatabase.GUIDToAssetPath(flagGuid);
                var flag = AssetDatabase.LoadAssetAtPath<GameFlag>(path);
                allFlags.Add(flag);
            }
        }
#endif

        public void SetFlag(string flagName, bool value)
        {
            allFlags.FirstOrDefault(f => f.name.Equals(flagName))?.Set(value);
        }
    }
}