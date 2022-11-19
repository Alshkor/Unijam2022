using Ui;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
    public class MainMenu : CancelableUi
    {
        #region Attributes

        [SerializeField] private Image image;

        [SerializeField] private GameObject sellMenu;
        [SerializeField] private GameObject buyMenu;
        [SerializeField] private Button sellButton;
        [SerializeField] private Button buyButton;
        

        #endregion

        private void OnEnable()
        {
            image.color = GameManager.Instance.getColor();
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(sellButton.gameObject);
        }

        #region Override methods

        public override void Cancel()
        {
            
        }
        
        public override void SetButtonClickEvent()
        {
            cancelButton.onClick.AddListener(() =>
            {
                GameManager.Instance.LoadNewLevel();
            });
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
