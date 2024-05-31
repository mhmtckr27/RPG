using RPG.Systems.DialogSystem.UI;
using UnityEngine;

namespace RPG.Systems.DialogSystem
{
    public class DialogGiver : MonoBehaviour
    {
        [SerializeField] private TextAsset dialogAsset;

        private void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent(out ThirdPersonMovement player))
                return;

            var dialogController = FindObjectOfType<DialogController>(true);
            dialogController.Show();
            dialogController.StartDialog(dialogAsset);
            // transform.LookAt(player.transform);
        }
    }
}