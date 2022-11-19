using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
    public class BuyMenu : CancelableUi
    {
        #region Attributes
        [SerializeField] private Image image;

        [SerializeField] private Button currentStaminaButton;
        [SerializeField] private Button maxStaminaButton;
        [SerializeField] private int priceCurrentStamina;
        [SerializeField] private int priceMaxStamina;
        [SerializeField] private TextMeshProUGUI priceCurrentStaminaText;
        [SerializeField] private TextMeshProUGUI priceMaxStaminaText;
        [SerializeField] private float boostStamina;
        [SerializeField] private float boostMaxStamina;
        

        #endregion
        
        private void OnEnable()
        {
            image.color = GameManager.Instance.getColor();
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(cancelButton.gameObject);
        }

        #region Override methods

        public override void SetButtonClickEvent()
        {
            base.SetButtonClickEvent();
            currentStaminaButton.onClick.AddListener(BuyCurrentStamina);
            priceCurrentStaminaText.text = priceCurrentStamina + " CAD";
            currentStaminaButton.onClick.AddListener(BuyMaxStamina);
            priceMaxStaminaText.text = priceMaxStamina + " CAD";
        }

        #endregion

        #region Private methods

        private void BuyCurrentStamina()
        {
            var manager = ItemManager.Instance;
            if (manager.Money < priceCurrentStamina)
                return;
            if (GameManager.Instance.MaxStamina < boostStamina + GameManager.Instance.PlayerStamina)
                return;

            manager.Money -= priceCurrentStamina;

            GameManager.Instance.PlayerStamina += boostStamina;
        }
        
        private void BuyMaxStamina()
        {
            var manager = ItemManager.Instance;
            if (manager.Money < priceMaxStamina)
                return;

            manager.Money -= priceMaxStamina;

            GameManager.Instance.MaxStamina += boostMaxStamina;
        }

        #endregion
    }
}
