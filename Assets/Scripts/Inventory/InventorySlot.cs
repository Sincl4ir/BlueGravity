using BlueGravity.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BlueGravity.Inventory
{
    [System.Serializable]
    public class InventorySlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _childInventoryItem;
        [SerializeField] private Image _childSpriteRenderer;
        private UIManager _UIManager;
        private InventoryItem _inventoryItem;
        public bool IsChildActive { get; private set; }
        public InventoryItem InventoryItem => _inventoryItem;

        public void SetUIManager(UIManager uiManager)
        {
            _UIManager = uiManager;
        }

        public void SetInvetoryItem(InventoryItem item)
        {
            _inventoryItem = item;
            _childSpriteRenderer.sprite = item.Sprite;
            IsChildActive = true;
            //Debug.Log(IsChildActive);
            _childInventoryItem.SetActive(IsChildActive);
        }

        public void UnsetInventoryItem()
        {
            _inventoryItem = null;
            IsChildActive = false;
            _childInventoryItem.SetActive(IsChildActive);
            _UIManager.RemoveDescriptionText();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(_inventoryItem == null) { return; }
            if(_UIManager == null) { return; }

            //Tapestry callback
            var uimanagers = FindObjectsOfType<UIManager>();
            for (int i = 0; i < uimanagers.Length; i++)
            {
                uimanagers[i].UnSelectInventoryItem();
            }
            _UIManager.SetSelectedInventoryItem(_inventoryItem, this);
            _UIManager.SetDescriptionText(_inventoryItem);
            //Debug.Log("Setting inventory item as it was clicked");
        }
    }
}
//EOF.
