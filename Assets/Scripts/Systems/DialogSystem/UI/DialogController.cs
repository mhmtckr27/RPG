using System.Collections.Generic;
using System.Text;
using Ink.Runtime;
using RPG.Systems.GameEvents;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RPG.Systems.DialogSystem.UI
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private TMP_Text dialogText;
        [SerializeField] private List<Button> responseButtons;
        [SerializeField] private Animator doorAnimator;
        
        private Story _story;
        private static readonly int OpenDoorTrigger = Animator.StringToHash("Open");

        public void StartDialog(TextAsset dialogAsset)
        {
            _story = new Story(dialogAsset.text);
            RefreshView();
        }

        private void RefreshView()
        {
            var dialogTextBuilder = new StringBuilder();

            while (_story.canContinue)
            {
                dialogTextBuilder.Append(_story.Continue());
                ProcessTags();
            }

            dialogText.SetText(dialogTextBuilder);
            
            for (var i = 0; i < responseButtons.Count; i++)
            {
                var responseButton = responseButtons[i];
                var shouldActivate =  i < _story.currentChoices.Count;
                
                responseButton.gameObject.SetActive(shouldActivate);
                responseButton.onClick.RemoveAllListeners();
                
                if(!shouldActivate)
                    continue;

                var choice = _story.currentChoices[i];
                responseButton.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                responseButton.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefreshView();
                });
            }
        }

        private void ProcessTags()
        {
            foreach (var currentTag in _story.currentTags)
            {
                Debug.Log(currentTag);
                if (currentTag.StartsWith("GE_"))
                {
                    GameEvent.RaiseEvent(currentTag.Remove(0, 3));
                }
            }
        }
    }
}