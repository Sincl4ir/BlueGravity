using UnityEngine;
using UnityEngine.Events;

namespace BlueGravity.Currency
{
    public class CurrencyController : MonoBehaviour
    {
        [SerializeField] private int _funds;

        public UnityEvent<int> FundsUpdatedEvent;
        public int Funds => _funds;
        public bool CanAffordCost(int cost) => _funds >= cost;

        public void SubstractFromFunds(int amount)
        {
            _funds -= amount;
            FundsUpdatedEvent?.Invoke(Funds);
        }

        public void AddToFunds(int amount)
        {
            _funds += amount;
            FundsUpdatedEvent?.Invoke(Funds);
        }
    }
}
//EOF.