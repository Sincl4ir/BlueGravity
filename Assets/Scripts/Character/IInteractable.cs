using BGS.DialogueSystem;

namespace BlueGravity.Character
{
    public interface IInteractable
    {
        void Interact();
        void PreInteraction();
        void ExitInteraction();
    }
}