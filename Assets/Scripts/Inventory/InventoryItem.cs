using UnityEngine;

namespace BlueGravity.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory Item", menuName = "BGS/Inventory Item")]
    public class InventoryItem : ScriptableObject, IEquipable
    {
        [SerializeField] public Sprite Sprite;
        [SerializeField] public string Name;
        [SerializeField] public EquipLocation EquipLocation;
        [SerializeField] public int Value;
        [TextArea(3,3)]
        [SerializeField] public string Description;
        [SerializeField] public AnimatorOverrideController AnimatorOverrideController;

        public void OnEquip()
        {
            Debug.Log($"Item {Name} equipped");
        }
    }
}
//EOF.