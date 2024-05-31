using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RPG.Systems.QuestSystem
{
    [CreateAssetMenu(menuName = "RPG/Scriptable Objects/Quest System/Quest", fileName = "SO_Quest_")]
    public class Quest : ScriptableObject
    {
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public List<Step> Steps { get; private set; }

#if UNITY_EDITOR
        [Tooltip("For developers/designers. Not visible to player.")]
        [SerializeField] private string notes;
#endif
    }

    [Serializable]
    public class Step
    {
        [field: SerializeField] public string Instructions { get; private set; }
        [field: SerializeField] public List<Objective> Objectives { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(Instructions);
            
            foreach (var objective in Objectives)
            {
                builder.AppendLine(objective.ToString());
            }

            return builder.ToString();
        }
    }

    [Serializable]
    public class Objective
    {
        [field: SerializeField] public ObjectiveType ObjectiveType { get; private set;  }

        public override string ToString()
        {
            return ObjectiveType.ToString();
        }
    }        
    
    public enum ObjectiveType
    {
        None = -1,
        Flag = 100,
        Item = 200,
        Kill = 300
    }
}