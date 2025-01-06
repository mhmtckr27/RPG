using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RPG.Systems.QuestSystem
{
    [CreateAssetMenu(menuName = "RPG/Scriptable Objects/Quest System/Quest", fileName = "SO_Quest_")]
    public class Quest : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public List<Step> Steps { get; private set; }

        private int _currentStepIndex;

        public event Action OnProgressed;

        public Step CurrentStep => Steps[_currentStepIndex];

        private void OnEnable() => _currentStepIndex = 0;
        
#if UNITY_EDITOR
        [Tooltip("For developers/designers. Not visible to player.")]
        [SerializeField] private string notes;
#endif
        public void TryProgress()
        {
            if(_currentStepIndex == -1 || Steps.Count <= _currentStepIndex)
                return;

            if (Steps[_currentStepIndex].HasAllObjectivesCompleted())
            {
                _currentStepIndex++;
                //TODO: do the stuff when you want to do on step completed.
                OnProgressed?.Invoke();
            }
        }
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

        public bool HasAllObjectivesCompleted()
        {
            return Objectives.TrueForAll(o => o.IsCompleted);
        }
    }

    [Serializable]
    public class Objective
    {
        [field: SerializeField] public ObjectiveType ObjectiveType { get; private set;  }
        [field: SerializeField] public GameFlag Flag { get; private set; }

        public bool IsCompleted
        {
            get
            {
                return ObjectiveType switch
                {
                    ObjectiveType.Flag => Flag.Value,
                    _ => true
                };
            }
        }

        public override string ToString()
        {
            return ObjectiveType switch
            {
                ObjectiveType.Flag => Flag.name,
                _ => ObjectiveType.ToString()
            };
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