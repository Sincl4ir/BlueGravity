using System;
using UnityEngine;
using BlueGravity.Tapestry;
using BlueGravity.EquipmentSystem;
using System.Collections.Generic;

namespace BlueGravity.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [Range(1, 6)]
        [SerializeField] private int _inventorySize = 6;
        [SerializeField] private Equipment _equipment;
        [SerializeField] private List<InventoryItem> _items;
        
        private int _currentItemsInInventory = 0;
        public int InventorySize => _inventorySize;

        private void OnEnable()
        {
            TapestryEventRegistry.OnItemEquippedTE.RemoveRepeatingMethod(ItemEquipped);
            TapestryEventRegistry.OnItemEquippedTE.SubscribeMethod(ItemEquipped);

            TapestryEventRegistry.OnItemUnequippedTE.RemoveRepeatingMethod(HandleItemUnequipped);
            TapestryEventRegistry.OnItemUnequippedTE.SubscribeMethod(HandleItemUnequipped);

            TapestryEventRegistry.OnTryToAddItemToInventoryTE.RemoveRepeatingMethod(AddItemToInventory);
            TapestryEventRegistry.OnTryToAddItemToInventoryTE.SubscribeMethod(AddItemToInventory);

            TapestryEventRegistry.OnItemPurchasedByPlayerTE.RemoveRepeatingMethod(AddItemToInventory);
            TapestryEventRegistry.OnItemPurchasedByPlayerTE.SubscribeMethod(AddItemToInventory);

            TapestryEventRegistry.OnItemSoldByPlayerTE.RemoveRepeatingMethod(RemoveItemFromInventory);
            TapestryEventRegistry.OnItemSoldByPlayerTE.SubscribeMethod(RemoveItemFromInventory);
        }

        private void Start()
        {
            TapestryEventRegistry.OnInventoryInitializedTE.Invoke(_inventorySize);

            if (_items.Count <= 0) { return; }

            foreach (var item in _items)
            {
                AddItemToInventory(item);
            }
        }
        public void AddItemToInventory(InventoryItem item)
        {
            if (!AvailableSpaceInInventory())
            {
                Debug.Log("Not enough space");
                return;
            }

            _currentItemsInInventory++;
            TapestryEventRegistry.OnInventoryItemAddedTE.Invoke(item);
        }

        private void HandleItemUnequipped(InventoryItem item)
        {
            _currentItemsInInventory++;
            TapestryEventRegistry.OnInventoryItemAddedTE.Invoke(item);
        }

        public void RemoveItemFromInventory(InventoryItem item)
        {
            _currentItemsInInventory--;
            TapestryEventRegistry.OnInventoryItemRemovedTE.Invoke(item);
        }
        public void ItemEquipped(InventoryItem item)
        {
            _equipment.OnItemEquipped(item);
            RemoveItemFromInventory(item);
        }
        
        public bool AvailableSpaceInInventory()
        {
            return _currentItemsInInventory <= _inventorySize;
        }

        private void OnDisable()
        {
            TapestryEventRegistry.OnItemEquippedTE.RemoveRepeatingMethod(ItemEquipped);
            TapestryEventRegistry.OnItemUnequippedTE.RemoveRepeatingMethod(HandleItemUnequipped);
            TapestryEventRegistry.OnTryToAddItemToInventoryTE.RemoveRepeatingMethod(AddItemToInventory);
            TapestryEventRegistry.OnItemPurchasedByPlayerTE.RemoveRepeatingMethod(AddItemToInventory);
            TapestryEventRegistry.OnItemSoldByPlayerTE.RemoveRepeatingMethod(RemoveItemFromInventory);
        }
    }
}
//EOF.