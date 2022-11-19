using Ui;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class MainMenu : CancelableUi
    {
        #region Attributes

        [SerializeField] private GameObject sellMenu;
        [SerializeField] private GameObject buyMenu;
        [SerializeField] private Button sellButton;
        [SerializeField] private Button buyButton;

        #endregion

        #region Override methods

        public override void Cancel()
        {
            
        }
        
        public override void SetButtonClickEvent()
        {
            cancelButton.onClick.AddListener(() => GameManager.Instance.LoadNewLevel());
            sellButton.onClick.AddListener(() =>
            {
                sellMenu.SetActive(true);
                gameObject.SetActive(false);
                UiManager.Instance.currentUi = sellMenu.GetComponent<CancelableUi>();
            });
            buyButton.onClick.AddListener(() =>
            {
                buyMenu.SetActive(true);
                gameObject.SetActive(false);
                UiManager.Instance.currentUi = buyMenu.GetComponent<CancelableUi>();
            });
        }

        #endregion

    }
}
