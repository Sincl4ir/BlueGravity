using UnityEngine;

namespace BlueGravity.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Blue Gravity/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] public DialogueNode[] _nodes;
    }
}
//EOF.