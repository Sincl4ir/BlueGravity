using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.DialogueSystem
{
    [System.Serializable]
    public class DialogueNode
    {
        [SerializeField] public string ID;
        [TextArea(3, 3)]
        [SerializeField] public string _text;
        [SerializeField] public List<DialogueAction> DialogueActions;
    }
}
//EOF.