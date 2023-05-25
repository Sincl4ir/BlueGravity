using System.Collections.Generic;
using UnityEngine;
using BlueGravity.Controller;

namespace BlueGravity.Inventory
{
    public class Equipment : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        private Dictionary<EquipLocation, GameObject> _equipLocationDict;
        [SerializeField] private InventoryItem _equippedItem;
        private List<InventoryItem> _itemsEquipped = new List<InventoryItem>();
        private void OnEnable()
        {
            InventoryManager.Instance.ItemEquippedEvent += OnItemEquipped;
        }

        private void Start()
        {
            _itemsEquipped.Add(_equippedItem);
        }
        private bool OnItemEquipped(InventoryItem obj)
        {
            Debug.Log($"InvetoryItem: {obj.Name} was equipped");
            if (obj.AnimatorOverrideController == null) { return true; }

            for (int i = 0; i < _itemsEquipped.Count; i++)
            {
                if (_itemsEquipped[i].EquipLocation != obj.EquipLocation) { continue; }
                InventoryManager.Instance.AddItemToInventory(_itemsEquipped[i]);
                _itemsEquipped.RemoveAt(i);
            }

            _itemsEquipped.Add(obj);
            //_player.ReplaceRuntimeAnimatorController(obj.AnimatorOverrideController);
            return true;
        }

        private void OnDisable()
        {
            InventoryManager.Instance.ItemEquippedEvent -= OnItemEquipped;
        }
    }
}
//EOF.