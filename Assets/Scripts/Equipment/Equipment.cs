using System.Collections.Generic;
using UnityEngine;
using BlueGravity.Tapestry;
using BlueGravity.Inventory;
using System.Collections;

namespace BlueGravity.EquipmentSystem
{
    public class Equipment : MonoBehaviour
    {
        [SerializeField] private List<EquipmentReference> _equipmentReferences = new List<EquipmentReference>();
        [SerializeField] private List<InventoryItem> _itemsEquipped = new List<InventoryItem>();

        private int _indexToUnequip;
        public bool OnItemEquipped(InventoryItem item)
        {
            for (int i = 0; i < _itemsEquipped.Count; i++)
            {
                if (_itemsEquipped[i].EquipLocation != item.EquipLocation) { continue; }
                _indexToUnequip = i;
                StartCoroutine(UnEquipCoroutine());
            }

            _itemsEquipped.Add(item);
            EquipItem(item);

            return true;
        }

        private void EquipItem(InventoryItem item)
        {
            SetSpriteRenderer(item);
            if (!item.HasPairedItem) { return; }
            
            SetSpriteRenderer(item.PairedItem);
        }

        private void SetSpriteRenderer(InventoryItem item)
        {
            var renderer = _equipmentReferences.Find(x => x.EquipLocation == item.EquipLocation).SpriteRenderer;
            renderer.sprite = item.Sprite;
        }

        IEnumerator UnEquipCoroutine()
        {
            yield return new WaitForSeconds(0.15f);
            TapestryEventRegistry.OnItemUnequippedTE.Invoke(_itemsEquipped[_indexToUnequip]);
            _itemsEquipped.RemoveAt(_indexToUnequip);
        }
    }
}
//EOF.