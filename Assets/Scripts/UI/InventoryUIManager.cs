using BlueGravity.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;
using BlueGravity.Tapestry;
using System.Linq;

namespace BlueGravity.UI
{
    public class InventoryUIManager : UIManager
    {
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _inventorySlotPrefab;
        [Range(1,6)]
        [SerializeField] private int _inventorySize;

        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();
        public List<InventorySlot> CurrentInventory => _inventorySlots;

        private void OnEnable()
        {
            TapestryEventRegistry.OnInventoryInitializedTE.RemoveRepeatingMethod(UpdateCurrentInventory);
            TapestryEventRegistry.OnInventoryInitializedTE.SubscribeMethod(UpdateCurrentInventory);

            TapestryEventRegistry.OnInventoryItemAddedTE.RemoveRepeatingMethod(AddItemToInventory);
            TapestryEventRegistry.OnInventoryItemAddedTE.SubscribeMethod(AddItemToInventory);

            TapestryEventRegistry.OnInventoryItemRemovedTE.RemoveRepeatingMethod(RemoveItemFromInventory);
            TapestryEventRegistry.OnInventoryItemRemovedTE.SubscribeMethod(RemoveItemFromInventory);

            TapestryEventRegistry.OnGetItemToStartTransactionTE.RemoveRepeatingMethod(TrySellInventoryItem);
            TapestryEventRegistry.OnGetItemToStartTransactionTE.SubscribeMethod(TrySellInventoryItem, false);
        }

        private void TrySellInventoryItem()
        {
            TapestryEventRegistry.OnPlayerTrySellItemTE.Invoke(_selectedInventoryItem);
        }

        private void UpdateCurrentInventory(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                GameObject go = Instantiate(_inventorySlotPrefab, _inventorySlotParent);
                var slot = go.GetComponent<InventorySlot>();
                slot.SetUIManager(this);
                _inventorySlots.Add(slot);
            }
        }

        public void AddItemToInventory(InventoryItem item)
        {
            var slot = _inventorySlots.First(x => !x.IsChildActive);
            if (slot == null) { return; }
            slot.SetInvetoryItem(item);
            Debug.Log("Added" + slot.InventoryItem.Name);
        }

        public void RemoveItemFromInventory(InventoryItem item)
        {
            RemoveItemFromInventorySlot(GetInventorySlot(item));
        }

        public InventorySlot GetInventorySlot(InventoryItem item)
        {
            var slot = _inventorySlots.Find(x => x.IsChildActive && x.InventoryItem.Name.Equals(item.Name));
            return slot;
        }

        public void RemoveItemFromInventorySlot(InventorySlot slot)
        {
            if (slot != null) { slot.UnsetInventoryItem(); }
            UnSelectInventoryItem();
        }

        public void HandleEquipment()
        {
            if (_selectedInventoryItem == null) { return; }
            TapestryEventRegistry.OnItemEquippedTE.Invoke(_selectedInventoryItem);
            UnSelectInventoryItem();
        }

        public void CloseUI()
        {
            _uiContainer.SetActive(false);
        }

        public void OpenUI()
        {
            _uiContainer.SetActive(true);
        }

        private void OnDisable()
        {
            TapestryEventRegistry.OnInventoryInitializedTE.RemoveRepeatingMethod(UpdateCurrentInventory);
            TapestryEventRegistry.OnInventoryItemAddedTE.RemoveRepeatingMethod(AddItemToInventory);
            TapestryEventRegistry.OnInventoryItemRemovedTE.RemoveRepeatingMethod(RemoveItemFromInventory);
            TapestryEventRegistry.OnGetItemToStartTransactionTE.RemoveRepeatingMethod(TrySellInventoryItem);
        }
    }
}
//EOF.