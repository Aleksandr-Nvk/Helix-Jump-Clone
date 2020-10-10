using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Models;

namespace UIViews
{
    public class ShopView : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField] private Button _closeButton;

        [SerializeField] private Button _setRedButton;
        [SerializeField] private Button _setGreenButton;
        [SerializeField] private Button _setBlueButton;
        [SerializeField] private Button _setYellowButton;
        [SerializeField] private Button _setPurpleButton;
        [SerializeField] private Button _setWhiteButton;
        [SerializeField] private Button _setOrangeButton;
        [SerializeField] private Button _setPinkButton;
        [SerializeField] private Button _setBlackButton;
        
#pragma warning restore

        public UnityAction OnCloseButtonPressed;

        public void Init(ShopManager shopManager)
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);

            _setRedButton.onClick.AddListener(() => shopManager.SetColor(Color.red));
            _setGreenButton.onClick.AddListener(() => shopManager.SetColor(Color.green));
            _setBlueButton.onClick.AddListener(() => shopManager.SetColor(Color.blue));
            _setYellowButton.onClick.AddListener(() => shopManager.SetColor(Color.yellow));
            _setPurpleButton.onClick.AddListener(() => shopManager.SetColor(new Color(140 , 0 , 190)));
            _setWhiteButton.onClick.AddListener(() => shopManager.SetColor(Color.white));
            _setOrangeButton.onClick.AddListener(() => shopManager.SetColor(new Color(255 , 160 , 0)));
            _setPinkButton.onClick.AddListener(() => shopManager.SetColor(Color.magenta));
            _setBlackButton.onClick.AddListener(() => shopManager.SetColor(Color.black));
        }

        /// <summary>
        /// Shows the view
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides the view
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}