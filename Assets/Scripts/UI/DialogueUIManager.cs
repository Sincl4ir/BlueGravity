using TMPro;
using UnityEngine;
using BlueGravity.DialogueSystem;

namespace BlueGravity.UI
{
    public class DialogueUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private Transform _buttonsHolder;
        [SerializeField] private GameObject _buttonPrefab;

        public void SetDialogueText(string dialogue)
        {
            _dialogueText.text = dialogue;
        }

        public void CreateResponseButton(DialogueAction response)
        {
            GameObject go = Instantiate(_buttonPrefab, _buttonsHolder);
            go.GetComponent<DialogueButton>().InitConfiguration(response);
        }
        public void HandleResponse(DialogueAction response)
        {
            DialogueManager.Instance.HandleDialogueResponse(response);
        }

        public void HandleDialogueClosure()
        {
            foreach (Transform child in _buttonsHolder)
            {
                Destroy(child.gameObject);
            }
            EnableDialogueUI(false);
            DialogueManager.Instance.HandleDialogueUIClosure();
        }

        public void EnableDialogueUI(bool enable)
        {
            _uiContainer.SetActive(enable);
        }
    }
}
//EOF.