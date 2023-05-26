using BlueGravity.Inventory;
using System.Collections.Generic;

namespace BlueGravity.Tapestry
{
    public class TapestryEventRegistry
    {

        #region Inventory
        /// <summary>
        /// Called on Player initialization in order to create inventory for the specific size.
        /// </summary>
        public static TapestryEvent<int> OnInventoryInitializedTE;
        
        /// <summary>
        /// Inventory item added to inventory.
        /// </summary>
        public static TapestryEvent<InventoryItem> OnInventoryItemAddedTE;

        /// <summary>
        /// Inventory item added to inventory.
        /// </summary>
        public static TapestryEvent<InventoryItem> OnTryToAddItemToInventoryTE;

        /// <summary>
        /// Inventory item removed from inventory.
        /// </summary>
        public static TapestryEvent<InventoryItem> OnInventoryItemRemovedTE;


        #endregion

        #region Equipment
        /// <summary>
        /// Inventory Item equipped succesfully on inventory.
        /// </summary>
        public static TapestryEvent<InventoryItem> OnItemEquippedTE;

        /// <summary>
        /// Inventory Item unequipped succesfully on inventory.
        /// </summary>
        public static TapestryEvent<InventoryItem> OnItemUnequippedTE;
        #endregion

        #region Shop
        /// <summary>
        /// On Shop Opened
        /// </summary>
        public static TapestryEvent<List<InventoryItem>, int> OnShopOpenedTE;

        /// <summary>
        /// On Shop Closed
        /// </summary>
        public static TapestryEvent OnShopClosedTE;

        /// <summary>
        /// On Item Sold
        /// </summary>
        public static TapestryEvent<InventoryItem> OnItemSoldByPlayerTE;

        /// <summary>
        /// On Item Bought
        /// </summary>
        public static TapestryEvent<InventoryItem> OnItemPurchasedByPlayerTE;

        /// <summary>
        /// On attempt to sell an item
        /// </summary>
        public static TapestryEvent<InventoryItem> OnPlayerTrySellItemTE;

        /// <summary>
        /// On attempt to get an item before proceeding with operations
        /// </summary>
        public static TapestryEvent OnGetItemToStartTransactionTE;

        /// <summary>
        /// On attempt to purchase an item
        /// </summary>
        public static TapestryEvent<InventoryItem> OnPlayerTryPurchaseItemTE;

        #endregion
        static TapestryEventRegistry()
        {
            CreateTapestryEvents();
        }

        private static void CreateTapestryEvents()
        {

            #region Inventory
            OnInventoryInitializedTE = new TapestryEvent<int>();
            OnInventoryItemAddedTE = new TapestryEvent<InventoryItem>();
            OnTryToAddItemToInventoryTE = new TapestryEvent<InventoryItem>();
            OnInventoryItemRemovedTE = new TapestryEvent<InventoryItem>();
            #endregion

            #region Equipment
            OnItemEquippedTE = new TapestryEvent<InventoryItem>();
            OnItemUnequippedTE = new TapestryEvent<InventoryItem>();
            #endregion

            #region Shop
            OnShopOpenedTE = new TapestryEvent<List<InventoryItem>, int>();
            OnShopClosedTE = new TapestryEvent();
            OnItemSoldByPlayerTE = new TapestryEvent<InventoryItem>();
            OnItemPurchasedByPlayerTE = new TapestryEvent<InventoryItem>();
            OnPlayerTryPurchaseItemTE = new TapestryEvent<InventoryItem>();
            OnPlayerTrySellItemTE = new TapestryEvent<InventoryItem>();
            OnGetItemToStartTransactionTE = new TapestryEvent();
            #endregion
        }

        public static void OnDestroy()
        {
            // Creates new events to clear the old ones
            CreateTapestryEvents();
        }
    }
}
//EOF.