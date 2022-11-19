using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class BuyMenu : CancelableUi
    {
        #region Attributes

        [SerializeField] private Button staminaButton;

        #endregion

        #region Override methods

        public override void SetButtonClickEvent()
        {
            base.SetButtonClickEvent();
            staminaButton.onClick.AddListener(BuyStamina);
        }

        #endregion

        #region Private methods

        private void BuyStamina()
        {
            
        }

        #endregion
    }
}
