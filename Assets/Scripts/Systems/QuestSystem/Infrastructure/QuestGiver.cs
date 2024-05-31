using RPG.Systems.QuestSystem.Application;
using RPG.Systems.QuestSystem.Representation;
using UnityEngine;

namespace RPG.Systems.QuestSystem.Infrastructure
{
    public class QuestGiver : MonoBehaviour, IQuestGiver
    {
        [SerializeField] private Quest quest;
        
        public void GiveQuest()
        {
            QuestManager.Instance.SelectQuest(quest);
        }
    }
}