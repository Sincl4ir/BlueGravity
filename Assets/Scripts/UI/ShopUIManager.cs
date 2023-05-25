using System.Collections.Generic;
using UnityEngine;
using BlueGravity.Inventory;
//using BlueGravity.Character;
using UnityEngine.Events;

namespace BlueGravity.UI
{
    public class ShopUIManager : UIManager
    {
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _inventorySlotPrefab;
        /*
        private List<InventorySlot> _currentItemsInShop = new List<InventorySlot>();
        private Shopper _shopper;
        private CurrencyController _player;
        private int _inventorySize;

        public UnityEvent OnOpenShopEvent;
        private void PopulateShopItems(List<InventoryItem> items)
        {
            if (items.Count > _inventorySize) { return; }

            foreach (var item in items )
            {
                GameObject go = Instantiate(_inventorySlotPrefab, _inventorySlotParent);
                InventorySlot slot = go.GetComponent<InventorySlot>();
                slot.SetInvetoryItem(item);
                slot.SetUIManager(this);
                _currentItemsInShop.Add(slot);
            }

            if (items.Count < _inventorySize)
            {
                int diff = _inventorySize - items.Count;
                for (int i = 0; i < diff; i++)
                {
                    GameObject go = Instantiate(_inventorySlotPrefab, _inventorySlotParent);
                    InventorySlot slot = go.GetComponent<InventorySlot>();
                    _currentItemsInShop.Add(slot);
                }
            }
        }

        private void UnpopulateShopItems()
        {
            foreach (Transform child in _inventorySlotParent)
            {
                Destroy(child.gameObject);
            }
        }

        public void UpdateShopItems(List<InventoryItem> items)
        {
            UnpopulateShopItems();
            PopulateShopItems(items);
        }
        public void OpenShop(List<InventoryItem> items, int inventorySize)
        {
            _inventorySize = inventorySize;
            PopulateShopItems(items);
            _uiContainer.SetActive(true);
            _shopper = FindObjectOfType<Shopper>();
            _player = FindObjectOfType<PlayerController>().GetComponent<CurrencyController>();
            OnOpenShopEvent?.Invoke();
        }

        public void CloseShop()
        {
            UnpopulateShopItems();
            _uiContainer.SetActive(false);
            _currentItemsInShop.Clear();
            _shopper.ShopClosed();
        }
        public void HandlePurchase()
        {
            if (_selectedInventoryItem == null) { return; }

            
            if (!_player.CanAffordCost(_selectedInventoryItem.Value)) 
            {
                Debug.Log("Can't afford");
                return;
            }
            //On success try to equip
            if (!InventoryManager.Instance.AddItemToInventory(_selectedInventoryItem))
            {
                Debug.Log("Error purchasing");
                return;
            }
            //handle payment
            _player.SubstractFromFunds(_selectedInventoryItem.Value);
            //remove from shop
            RemoveFromShopInventory(_selectedInventoryItem);
            _shopper.OnItemSold(_selectedInventoryItem);

            UnSelectInventoryItem();
        }

        public void HandleSale()
        {
            if (InventoryManager.Instance.GetSelectedItemInInventory() == null)
            {
                Debug.Log("No object selected in inventory");
                return;
            }
            if (!_shopper.OnItemBought(InventoryManager.Instance.GetSelectedItemInInventory()))
            {
                Debug.Log("Shopper could not buy");
                return;
            }
            _player.AddToFunds(InventoryManager.Instance.GetSelectedItemInInventory().Value);
            InventoryManager.Instance.RemoveItemFromInventory(InventoryManager.Instance.GetSelectedSlotInInventory());
            
        }
        public void RemoveFromShopInventory(InventoryItem item)
        {
            _selectedInventorySlot.UnsetInventoryItem();
        }*/
    }
}
//EOF.