using UnityEngine;
using BlueGravity.DialogueSystem;

namespace BlueGravity.Character
{
    public abstract class NPC : MonoBehaviour, IInteractable, IDialogable
    {
        [SerializeField] private Dialogue _dialogue;

        public virtual void ExitInteraction() { }
        public virtual void HandleResponse(DialogueAction action) { }
        public virtual void PreInteraction() { }

        public virtual void Interact()
        {
            if (DialogueManager.Instance.Interacting) { return; }
            DialogueManager.Instance.HandleDialogue(_dialogue, this.gameObject);
        }

    }
}
//EOF.