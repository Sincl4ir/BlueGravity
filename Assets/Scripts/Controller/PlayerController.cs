using BlueGravity.Character;
using BlueGravity.Currency;
using BlueGravity.Inventory;
using BlueGravity.Tapestry;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _moveAnimator = "Moving";
        [SerializeField] private CurrencyController _currencyController;
        [SerializeField] private InventoryManager _inventoryManager;

        private IInteractable _interactable;
        private Vector3 _direction;
        private int _moveAnimatorHash;
        private bool _enableController = true;

        private void OnEnable()
        {
            TapestryEventRegistry.OnPlayerTryPurchaseItemTE.RemoveRepeatingMethod(OnTryPurchaseItem);
            TapestryEventRegistry.OnPlayerTryPurchaseItemTE.SubscribeMethod(OnTryPurchaseItem);

            TapestryEventRegistry.OnItemSoldByPlayerTE.RemoveRepeatingMethod(OnItemSold);
            TapestryEventRegistry.OnItemSoldByPlayerTE.SubscribeMethod(OnItemSold);

            TapestryEventRegistry.OnShopOpenedTE.RemoveRepeatingMethod(OnShopOpened);
            TapestryEventRegistry.OnShopOpenedTE.SubscribeMethod(OnShopOpened, false);

            TapestryEventRegistry.OnShopClosedTE.RemoveRepeatingMethod(OnShopClosed);
            TapestryEventRegistry.OnShopClosedTE.SubscribeMethod(OnShopClosed,false);
        }

        private void OnShopClosed()
        {
            EnableController(true);
        }

        private void OnShopOpened(List<InventoryItem> arg1, int arg2)
        {
            EnableController(false);
        }

        private void OnItemSold(InventoryItem item)
        {
            _currencyController.AddToFunds(item.Value);
            TapestryEventRegistry.OnPlayerFundsUpdatedTE.Invoke(_currencyController.Funds);
        }

        private void OnTryPurchaseItem(InventoryItem item)
        {
            if (!_currencyController.CanAffordCost(item.Value)) { return; }
            if (!_inventoryManager.AvailableSpaceInInventory()) { return; }

            _currencyController.SubstractFromFunds(item.Value);
            TapestryEventRegistry.OnItemPurchasedByPlayerTE.Invoke(item);
            TapestryEventRegistry.OnPlayerFundsUpdatedTE.Invoke(_currencyController.Funds);
        }

        private void Start()
        {
            if (!_rigidbody) { TryGetComponent<Rigidbody2D>(out _rigidbody); }
            if (!_animator) { TryGetComponent<Animator>(out _animator); }

            _moveAnimatorHash = Animator.StringToHash(_moveAnimator);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)) { return; }
            _interactable = interactable;
            _interactable.PreInteraction();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (_interactable == null) { return; }
            _interactable.ExitInteraction();
            _interactable = null;
        }

        void Update()
        {
            if (!_enableController) { return; }

            if (Input.GetKey(KeyCode.E))
            {
                if (_interactable == null) { return; }
                _interactable.Interact();
            }
        }

        private void FixedUpdate()
        {
            if (!_enableController) { return; }

            _direction = Vector3.zero;
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");

            HandleMovement();
        }

        private void HandleMovement()
        {
            if (_direction == Vector3.zero)
            {
                _animator.SetBool(_moveAnimatorHash, false);
                return;
            }

            _animator.SetBool(_moveAnimatorHash, true);
            
            RotateCharacter();
            MoveCharacter();
        }

        public void EnableController(bool enable)
        {
            _enableController = enable;
        }
        private void MoveCharacter()
        {
            _rigidbody.MovePosition(transform.position + _direction * _speed * Time.deltaTime);
        }

        private void RotateCharacter()
        {
            var rot = _direction.x >= 0 ? 0 : 180;
            transform.rotation = Quaternion.Euler(0, rot, 0);
        }

        private void OnDisable()
        {
            TapestryEventRegistry.OnPlayerTryPurchaseItemTE.RemoveRepeatingMethod(OnTryPurchaseItem);
            TapestryEventRegistry.OnItemSoldByPlayerTE.RemoveRepeatingMethod(OnItemSold);
            TapestryEventRegistry.OnShopOpenedTE.RemoveRepeatingMethod(OnShopOpened);
            TapestryEventRegistry.OnShopClosedTE.RemoveRepeatingMethod(OnShopClosed);
        }
    }
}
//EOF.