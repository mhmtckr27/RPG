using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Systems.QuestSystem.Representation
{
    public class QuestPanelView : MonoBehaviour
    {
        private Quest _selectedQuest;
        
        [SerializeField] private TMP_Text displayNameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text objectivesText;
        [SerializeField] private Image icon;
        
        public void Refresh(Quest selectedQuest)
        {
            _selectedQuest = selectedQuest;
            displayNameText.SetText(_selectedQuest.DisplayName);
            descriptionText.SetText(_selectedQuest.Description);
            icon.sprite = _selectedQuest.Icon;

            RefreshObjectivesText();
        }

        private void RefreshObjectivesText()
        {
            var currentStep = _selectedQuest.Steps.FirstOrDefault();
            
            if(currentStep == null)
                return;
            
            objectivesText.SetText(currentStep.ToString());
        }
    }
}