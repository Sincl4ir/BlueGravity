using UnityEngine;
using UnityEngine.Events;

namespace BlueGravity.UI
{
    public class ActivateUI : MonoBehaviour
    {
        [SerializeField] private KeyCode _toggleKey;
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private bool _useFuncOnExit;
        public UnityEvent ExitInputCallReceived;

        // Start is called before the first frame update
        void Start()
        {
            _uiContainer.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(_toggleKey))
            {
                if (!_useFuncOnExit)
                {
                    _uiContainer.SetActive(!_uiContainer.activeInHierarchy);
                    return;
                }
                else if(_useFuncOnExit && _uiContainer.activeInHierarchy)
                {
                    ExitInputCallReceived?.Invoke();
                }
            }

        }

        public void HandleUIActivation(bool enable)
        {
            _uiContainer.SetActive(enable);
        }
    }
}
//EOF.