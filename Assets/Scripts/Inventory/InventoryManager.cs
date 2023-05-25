using System;
using UnityEngine;
//using BGS.UI;

namespace BlueGravity.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance { get; private set; }

        [Range(1, 6)]
        [SerializeField] private int _inventorySize;
        //[SerializeField] private InventoryUIManager _inventoryUIManager;

        public Func<InventoryItem, bool> ItemEquippedEvent;
        public event Action ItemEquippedSuccessfully;
        
        public int InventorySize => _inventorySize;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public bool AddItemToInventory(InventoryItem item)
        {
            //if (!AvailableSpaceInInventory())
            {
                Debug.Log("Not enough space");
                return false;
            }
            //_inventoryUIManager.AddItemToInventory(item);
            return true;
        }

        public void RemoveItemFromInventory(InventorySlot slot)
        {
            //_inventoryUIManager.RemoveItemFromInventory(slot);
        }
        public void ItemEquipped(InventoryItem item)
        {
            if (ItemEquippedEvent == null) { return; }
            if (ItemEquippedEvent(item))
            {
                Debug.Log("Item successfully equiped");
                ItemEquippedSuccessfully?.Invoke();
                //RemoveItemFromInventory(GetSelectedSlotInInventory());
            }
        }

        /*
        private bool AvailableSpaceInInventory()
        {
            List<InventorySlot> slots = _inventoryUIManager.CurrentInventory;
            foreach (var slot in slots)
            {
                if (!slot.IsChildActive) { return true; }
            }
            return false;
    }

        public InventoryItem GetSelectedItemInInventory()
        {
            return _inventoryUIManager.SelectedItem;
        }

        public InventorySlot GetSelectedSlotInInventory()
        {
            return _inventoryUIManager.SelectedSlot;
        }*/
    }
}
//EOF.