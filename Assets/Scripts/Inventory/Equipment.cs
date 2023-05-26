using System.Collections.Generic;
using UnityEngine;
using BlueGravity.Tapestry;

namespace BlueGravity.Inventory
{
    public class Equipment : MonoBehaviour
    {
        //[SerializeField] private InventoryItem _equippedItem;
        private List<InventoryItem> _itemsEquipped = new List<InventoryItem>();

        private void Start()
        {
            //_itemsEquipped.Add(_equippedItem);
        }
        public bool OnItemEquipped(InventoryItem obj)
        {
            Debug.Log($"InvetoryItem: {obj.Name} was equipped");

            for (int i = 0; i < _itemsEquipped.Count; i++)
            {
                if (_itemsEquipped[i].EquipLocation != obj.EquipLocation) { continue; }
                
                TapestryEventRegistry.OnItemUnequippedTE.Invoke(_itemsEquipped[i]);
                _itemsEquipped.RemoveAt(i);
            }

            _itemsEquipped.Add(obj);
            return true;
        }
    }
}
//EOF.