using System.Linq;
using RPG.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Systems.QuestSystem.Representation
{
    public class QuestPanelView : ToggleableView
    {
        private Quest _selectedQuest;
        
        [SerializeField] private TMP_Text displayNameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text objectivesText;
        [SerializeField] private Image icon;

        public void SelectQuest(Quest questToSelect)
        {
            if (_selectedQuest != null)
                _selectedQuest.OnProgressed -= Refresh;
            
            _selectedQuest = questToSelect;
            _selectedQuest.OnProgressed += Refresh;
            
            Refresh();
        }
        
        private void Refresh()
        {
            displayNameText.SetText(_selectedQuest.DisplayName);
            descriptionText.SetText(_selectedQuest.Description);
            icon.sprite = _selectedQuest.Icon;

            RefreshObjectivesText();
        }

        private void RefreshObjectivesText()
        {
            var currentStep = _selectedQuest.CurrentStep;
            
            if(currentStep == null)
                return;
            
            objectivesText.SetText(currentStep.ToString());
        }
    }
}