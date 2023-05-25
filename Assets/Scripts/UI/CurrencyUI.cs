using TMPro;
using UnityEngine;
using BlueGravity.Currency;

namespace BlueGravity.UI
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private CurrencyController _currencyController;
        [SerializeField] private TextMeshProUGUI _fundsText;

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
    }
}
//EOF.
