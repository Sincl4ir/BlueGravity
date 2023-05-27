using TMPro;
using UnityEngine;
using BlueGravity.Currency;
using BlueGravity.Tapestry;

namespace BlueGravity.UI
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private CurrencyController _currencyController;
        [SerializeField] private TextMeshProUGUI _fundsText;

        private void OnEnable()
        {
            TapestryEventRegistry.OnPlayerFundsUpdatedTE.RemoveRepeatingMethod(SetFunds);
            TapestryEventRegistry.OnPlayerFundsUpdatedTE.SubscribeMethod(SetFunds);

        }
        // Start is called before the first frame update
        void Start()
        {
            SetFunds(_currencyController.Funds);
        }
        
        public void SetFunds(int funds)
        {
            string str = "$" + funds.ToString();
            _fundsText.text = str;
        }

        private void OnDisable()
        {
            TapestryEventRegistry.OnPlayerFundsUpdatedTE.RemoveRepeatingMethod(SetFunds);
        }
    }
}
//EOF.
