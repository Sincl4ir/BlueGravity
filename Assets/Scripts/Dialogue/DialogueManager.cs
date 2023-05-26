using BlueGravity.Character;
using BlueGravity.UI;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField] private DialogueUIManager _dialogueUI;
        private NPC _transmitter;
        private List<DialogueAction> responses = new List<DialogueAction>();
        private bool _interacting = false;
        public bool Interacting => _interacting;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        public void HandleDialogue(Dialogue dialogue, NPC transmitter)
        {
            _interacting = true;
            _transmitter = transmitter;
            _dialogueUI.EnableDialogueUI(true);
            _dialogueUI.SetDialogueText(dialogue._nodes[0]._text);

            if (dialogue._nodes[0].DialogueActions.Count == 0) { return; }

            responses = dialogue._nodes[0].DialogueActions;
            
            foreach ( var response in responses)
            {
                _dialogueUI.CreateResponseButton(response);
            }
        }
    
        public void HandleDialogueResponse(DialogueAction action)
        {
            _transmitter.HandleResponse(action);
            if (action.EndsDialogue)
            {
                CloseDialogue();
            }
        }

        public void HandleDialogueUIClosure()
        {
            _interacting = false;
        }

        private void CloseDialogue()
        {
            _dialogueUI.HandleDialogueClosure();
        }
    }
}
//EOF.