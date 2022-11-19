using UI;
using UnityEngine;
using UnityEngine.EventSystems;
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

        [SerializeField] private int[] prices; //prix du plus bas au plus haut par ex : [10, 20, 30, 40]

        #endregion
        
        private void OnEnable()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(cancelButton.gameObject);
        }


        #region Override Methods

        public override void SetButtonClickEvent()
        {
            cancelButton.onClick.AddListener(Cancel);
            button1.onClick.AddListener(() => Sell(Item.ItemType.Bois));
            button2.onClick.AddListener(() => Sell(Item.ItemType.Or));
            button3.onClick.AddListener(() => Sell(Item.ItemType.Coquillage));
            //button4.onClick.AddListener(() => Sell(3));

        }

        #endregion


        #region Private Methods

        private void Sell(Item.ItemType itemType)
        {
            int biome = GameManager.Instance.biome;
            int money = 0;
            var manager = ItemManager.Instance;

            switch (itemType)
            {
                case Item.ItemType.Bois:
                    if (manager.GetItemValue(Item.ItemType.Bois) <= 0)
                        return;
                    money = prices[1 + biome % 4];
                    manager.PayItem(Item.ItemType.Bois, 1);
                    break;
                case Item.ItemType.Or:
                    if (manager.GetItemValue(Item.ItemType.Or) <= 0)
                        return;
                    money = prices[1 +(1 + biome) % 4];
                    manager.PayItem(Item.ItemType.Or, 1);
                    break;
                case Item.ItemType.Coquillage:
                    if (manager.GetItemValue(Item.ItemType.Coquillage) <= 0)
                        return;
                    money = prices[1 + (2 + biome) % 4];
                    manager.PayItem(Item.ItemType.Coquillage, 1);
                    break;
            }

            manager.Money += money;

        }

        #endregion
    }
}
