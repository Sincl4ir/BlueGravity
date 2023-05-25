using BlueGravity.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.UI
{
    public class InventoryUIManager : UIManager
    {
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _inventorySlotPrefab;
        [Range(1,6)]
        [SerializeField] private int _inventorySize;
        [SerializeField] private InventoryItem _item;

        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();
        public List<InventorySlot> CurrentInventory => _inventorySlots;


        private void OnEnable()
        {
            InventoryManager.Instance.ItemEquippedSuccessfully += OnItemEquippedSuccessfully;
        }

        private void Start()
        {
            UpdateCurrentInventory(InventoryManager.Instance.InventorySize);
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
            foreach (var slot in _inventorySlots)
            {
                if (slot.IsChildActive) { continue; }
                slot.SetInvetoryItem(item);
                Debug.Log("Added" + slot.InventoryItem.Name);
                break;
            }
        }

        public void RemoveItemFromInventory(InventorySlot slot)
        {
            foreach(var inventoryslot in _inventorySlots)
            {
                if (!inventoryslot.IsChildActive) { continue; }
                if (inventoryslot.InventoryItem.Name.Equals(slot.InventoryItem.Name))
                {
                    inventoryslot.UnsetInventoryItem();
                    UnSelectInventoryItem();
                    return;
                }
            }
        }
        private void OnItemEquippedSuccessfully()
        {
            //Debug.Log("Closing UI Shit");
        }

        public void HandleEquipment()
        {
            if (_selectedInventoryItem == null) { return; }
            Debug.Log("handling equipment");
            InventoryManager.Instance.ItemEquipped(_selectedInventoryItem);
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
    }
}
//EOF.