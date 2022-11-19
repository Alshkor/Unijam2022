using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class SellMenu : CancelableUi
    {
        #region Attributes

        [SerializeField] private Button button1;
        [SerializeField] private Button button2;
        [SerializeField] private Button button3;
        [SerializeField] private Button button4;

        #endregion


        #region Override Methods

        public override void SetButtonClickEvent()
        {
            cancelButton.onClick.AddListener(Cancel);
            button1.onClick.AddListener(() => Sell(0));
            button2.onClick.AddListener(() => Sell(1));
            button3.onClick.AddListener(() => Sell(2));
            button4.onClick.AddListener(() => Sell(3));

        }

        #endregion


        #region Private Methods

        private void Sell(int resources)
        {
            switch (resources)
            {
                
            }
        }

        #endregion
    }
}
