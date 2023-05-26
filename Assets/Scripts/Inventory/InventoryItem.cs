using BlueGravity.EquipmentSystem;
using UnityEngine;

namespace BlueGravity.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory Item", menuName = "Blue Gravity/Inventory Item")]
    public class InventoryItem : ScriptableObject, IEquipable
    {
        [SerializeField] public Sprite Sprite;
        [SerializeField] public string Name;
        [SerializeField] public EquipLocation EquipLocation;
        [SerializeField] public int Value;
        [SerializeField] public bool HasPairedItem;
        [SerializeField] public InventoryItem PairedItem;
        [TextArea(3,3)]
        [SerializeField] public string Description;

        public void OnEquip()
        {
            Debug.Log($"Item {Name} equipped");
        }
    }
}
//EOF.