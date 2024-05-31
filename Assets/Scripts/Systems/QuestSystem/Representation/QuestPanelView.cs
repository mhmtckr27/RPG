using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Systems.QuestSystem.Representation
{
    public class QuestPanelView : MonoBehaviour
    {
        [SerializeField] private Quest selectedQuest;
        [SerializeField] private TMP_Text displayNameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text objectivesText;
        [SerializeField] private Image icon;
        
        private void Awake()
        {
            Refresh();
        }

        private void Refresh()
        {
            displayNameText.SetText(selectedQuest.DisplayName);
            descriptionText.SetText(selectedQuest.Description);
            icon.sprite = selectedQuest.Icon;

            RefreshObjectivesText();
        }

        private void RefreshObjectivesText()
        {
            var currentStep = selectedQuest.Steps.FirstOrDefault();
            
            if(currentStep == null)
                return;
            
            objectivesText.SetText(currentStep.ToString());
        }
    }
}