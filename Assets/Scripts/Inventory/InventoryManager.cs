using System;
using UnityEngine;
using BlueGravity.UI;
using BlueGravity.Tapestry;

namespace BlueGravity.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [Range(1, 6)]
        [SerializeField] private int _inventorySize = 6;
        [SerializeField] private Equipment _equipment;

        private int _currentItemsInInventory = 0;

        public Func<InventoryItem, bool> ItemEquippedEvent;
        public event Action ItemEquippedSuccessfully;
        public int InventorySize => _inventorySize;

        private void OnEnable()
        {
            TapestryEventRegistry.OnItemEquippedTE.RemoveRepeatingMethod(ItemEquipped);
            TapestryEventRegistry.OnItemEquippedTE.SubscribeMethod(ItemEquipped);

            TapestryEventRegistry.OnItemUnequippedTE.RemoveRepeatingMethod(HandleItemUnequipped);
            TapestryEventRegistry.OnItemUnequippedTE.SubscribeMethod(HandleItemUnequipped);

            TapestryEventRegistry.OnTryToAddItemToInventoryTE.RemoveRepeatingMethod(AddItemToInventory);
            TapestryEventRegistry.OnTryToAddItemToInventoryTE.SubscribeMethod(AddItemToInventory);
        }
        private void Start()
        {
            TapestryEventRegistry.OnInventoryInitializedTE.Invoke(_inventorySize);
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
            //Tapestry call
            _currentItemsInInventory--;
            TapestryEventRegistry.OnInventoryItemRemovedTE.Invoke(item);
        }
        public void ItemEquipped(InventoryItem item)
        {
            _equipment.OnItemEquipped(item);
            RemoveItemFromInventory(item);
        }
        
        private bool AvailableSpaceInInventory()
        {
            return _currentItemsInInventory > _inventorySize;
        }

        private void OnDisable()
        {
            TapestryEventRegistry.OnItemEquippedTE.RemoveRepeatingMethod(ItemEquipped);
            TapestryEventRegistry.OnItemUnequippedTE.RemoveRepeatingMethod(HandleItemUnequipped);
            TapestryEventRegistry.OnTryToAddItemToInventoryTE.RemoveRepeatingMethod(AddItemToInventory);
        }
    }
}
//EOF.