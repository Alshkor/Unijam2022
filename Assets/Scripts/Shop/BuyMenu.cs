using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class BuyMenu : CancelableUi
    {
        #region Attributes

        [SerializeField] private Button staminaButton;
        [SerializeField] private int priceStamina;
        [SerializeField] private TextMeshProUGUI priceStaminaText;

        #endregion

        #region Override methods

        public override void SetButtonClickEvent()
        {
            base.SetButtonClickEvent();
            staminaButton.onClick.AddListener(BuyStamina);
            priceStaminaText.text = priceStamina + " CAD";
        }

        #endregion

        #region Private methods

        private void BuyStamina()
        {
            var manager = ItemManager.Instance;
            if (manager.Money < priceStamina)
                return;

            manager.Money -= priceStamina;
            
            //todo make stamina
        }

        #endregion
    }
}
