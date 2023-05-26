using BlueGravity.Inventory;

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
        }

        public static void OnDestroy()
        {
            // Creates new events to clear the old ones
            CreateTapestryEvents();
        }
    }
}
//EOF.