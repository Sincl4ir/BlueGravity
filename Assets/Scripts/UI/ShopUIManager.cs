using System.Collections.Generic;
using UnityEngine;
using BlueGravity.Inventory;
using BlueGravity.Character;
using BlueGravity.Currency;
using BlueGravity.Tapestry;
using System.Linq;

namespace BlueGravity.UI
{
    public class ShopUIManager : UIManager
    {
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _inventorySlotPrefab;
        
        private List<InventorySlot> _currentItemsInShop = new List<InventorySlot>();
        private Shopper _shopper;
        private CurrencyController _player;
        private int _inventorySize;

        private void OnEnable()
        {
            TapestryEventRegistry.OnShopOpenedTE.RemoveRepeatingMethod(OpenShop);
            TapestryEventRegistry.OnShopOpenedTE.SubscribeMethod(OpenShop, false);

            TapestryEventRegistry.OnItemSoldByPlayerTE.RemoveRepeatingMethod(AddItemToShopInventory);
            TapestryEventRegistry.OnItemSoldByPlayerTE.SubscribeMethod(AddItemToShopInventory);

            TapestryEventRegistry.OnItemPurchasedByPlayerTE.RemoveRepeatingMethod(RemoveFromShopInventory);
            TapestryEventRegistry.OnItemPurchasedByPlayerTE.SubscribeMethod(RemoveFromShopInventory);

        }

        private void AddItemToShopInventory(InventoryItem item)
        {
            var slot = _currentItemsInShop.First(x => !x.IsChildActive);
            if (slot == null) { return; }
            slot.SetInvetoryItem(item);
            Debug.Log("Added" + slot.InventoryItem.Name);
        }

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
                    slot.SetUIManager(this);
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
        }

        public void CloseShop()
        {
            UnpopulateShopItems();
            _uiContainer.SetActive(false);
            _currentItemsInShop.Clear();

            TapestryEventRegistry.OnShopClosedTE.Invoke();
        }
        public void HandlePurchase()
        {
            if (_selectedInventoryItem == null) { return; }

            TapestryEventRegistry.OnPlayerTryPurchaseItemTE.Invoke(_selectedInventoryItem);
            UnSelectInventoryItem();
        }

        public void HandleSale()
        {
            TapestryEventRegistry.OnGetItemToStartTransactionTE.Invoke();
        }

        public void RemoveFromShopInventory(InventoryItem item)
        {
            var slot = _currentItemsInShop.Find(x => x.IsChildActive && x.InventoryItem.Name.Equals(item.Name));
            slot.UnsetInventoryItem();
        }

        private void OnDisable()
        {
            TapestryEventRegistry.OnShopOpenedTE.RemoveRepeatingMethod(OpenShop);
            TapestryEventRegistry.OnItemSoldByPlayerTE.RemoveRepeatingMethod(AddItemToShopInventory);
            TapestryEventRegistry.OnItemPurchasedByPlayerTE.RemoveRepeatingMethod(RemoveFromShopInventory);
        }
    }
}
//EOF.