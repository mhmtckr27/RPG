using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Systems.QuestSystem.Representation
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager Instance { get; private set; }
        
        [SerializeField] private QuestPanelView questPanelView;

        private List<Quest> _quests = new();
        
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if(Instance != this)
                Destroy(gameObject);
        }

        public void SelectQuest(Quest quest)
        {
            questPanelView.Refresh(quest);
            questPanelView.gameObject.SetActive(true);
        }
    }
}