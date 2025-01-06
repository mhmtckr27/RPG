using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Systems.QuestSystem.Representation
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager Instance { get; private set; }
        
        [SerializeField] private QuestPanelView questPanelView;
        [SerializeField] private List<Quest> allQuests;

        private List<Quest> _currentQuests = new();


        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if(Instance != this)
                Destroy(gameObject);
        }

        public void SelectQuest(Quest quest)
        {
            questPanelView.SelectQuest(quest);
            questPanelView.Show();
        }

        public void AddQuestByName(string questID)
        {
            var questToAdd = allQuests.FirstOrDefault(q => q.ID.Equals(questID));

            if (questToAdd == null)
            {
                Debug.LogException(new Exception($"Tried to add quest '{questID}' " +
                                                 $"but it does not exist in QuestManager.allQuests!"));
                
                return;
            }
            
            _currentQuests.Add(questToAdd);
            SelectQuest(questToAdd);
        }

        [ContextMenu("Progress Quests")]
        public void ProgressQuests()
        {
            foreach (var currentQuest in _currentQuests)
            {
                currentQuest.TryProgress();
            }
        }
    }
}