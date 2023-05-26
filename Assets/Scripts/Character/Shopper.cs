using System.Collections.Generic;
using UnityEngine;
using BlueGravity.UI;
using BlueGravity.Inventory;
using BlueGravity.Currency;
using BlueGravity.DialogueSystem;
using BlueGravity.Tapestry;

namespace BlueGravity.Character
{
    public class Shopper : NPC
    {
        private ShopUIManager _shopUIManager;
        [Range(1, 6)]
        [SerializeField] private int _inventorySize;
        [SerializeField] private List<InventoryItem> _shopItems;
        [SerializeField] private CurrencyController _currencyController;
        [SerializeField] private GameObject _hud;

        private bool _shopping;
        private bool _interacting;

        private void OnEnable()
        {
            TapestryEventRegistry.OnItemPurchasedByPlayerTE.RemoveRepeatingMethod(OnItemSold);
            TapestryEventRegistry.OnItemPurchasedByPlayerTE.SubscribeMethod(OnItemSold);

            TapestryEventRegistry.OnPlayerTrySellItemTE.RemoveRepeatingMethod(OnTryPurchaseItem);
            TapestryEventRegistry.OnPlayerTrySellItemTE.SubscribeMethod(OnTryPurchaseItem);
        }

        private void OnTryPurchaseItem(InventoryItem item)
        {
            if (!_currencyController.CanAffordCost(item.Value)) { return; }
            if (_inventorySize < _shopItems.Count) { return; }

            OnItemPurchased(item);
            TapestryEventRegistry.OnItemSoldByPlayerTE.Invoke(item);
        }

        public override void Interact()
        {
            if (_interacting) { return; }
            if (_shopping) { return; }
            base.Interact();
            _hud.SetActive(false);
            _interacting = true;
        }

        public override void ExitInteraction()
        {
            base.ExitInteraction();
            _hud.SetActive(false);
            _interacting = false;
        }

        public override void PreInteraction()
        {
            if (_interacting) 
            {
                _hud.SetActive(false);
                return; 
            }
            _hud.SetActive(true);            
        }

        public override void HandleResponse(DialogueAction action)
        {
            if (!action.NeedsResponse) { return; }
            _hud.SetActive(false);

            TapestryEventRegistry.OnShopOpenedTE.Invoke(_shopItems, _inventorySize);
            _shopping = true;
        }

        public void OnItemSold(InventoryItem item)
        {
            var soldItem = _shopItems.Find(x => x.Name.Equals(item.Name));
            _currencyController.AddToFunds(item.Value);
            _shopItems.Remove(soldItem);
        }

        public void OnItemPurchased(InventoryItem item)
        {
            _currencyController.SubstractFromFunds(item.Value);
            _shopItems.Add(item);
        }

        public void ShopClosed()
        {
            _shopping = false;
            _interacting = false;
        }

        private void OnDisable()
        {
            TapestryEventRegistry.OnItemPurchasedByPlayerTE.RemoveRepeatingMethod(OnItemSold);
            TapestryEventRegistry.OnPlayerTrySellItemTE.RemoveRepeatingMethod(OnTryPurchaseItem);
        }
    }
}
//EOF.