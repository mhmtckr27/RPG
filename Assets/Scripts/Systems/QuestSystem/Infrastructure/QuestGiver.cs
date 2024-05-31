using RPG.Systems.QuestSystem.Representation;
using UnityEngine;

namespace RPG.Systems.QuestSystem.Infrastructure
{
    public class QuestGiver : MonoBehaviour
    {
        [SerializeField] private Quest quest;
        
        private void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent(out ThirdPersonMovement player))
                return;
            
            QuestManager.Instance.SelectQuest(quest);
        }
    }
}