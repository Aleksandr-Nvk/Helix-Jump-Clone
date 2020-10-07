using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

namespace UIViews
{
    public class ShopView : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField] private Button _closeButton;

#pragma warning restore

        public UnityAction OnCloseButtonPressed;

        public void Init()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
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