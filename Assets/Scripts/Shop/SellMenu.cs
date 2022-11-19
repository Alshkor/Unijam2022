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
            button1.onClick.AddListener(() => Sell(Item.ItemType.Violet));
            button2.onClick.AddListener(() => Sell(Item.ItemType.Orange));
            button3.onClick.AddListener(() => Sell(Item.ItemType.Bleu));
            button4.onClick.AddListener(() => Sell(Item.ItemType.Vert));

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
                case Item.ItemType.Violet:
                    if (manager.GetItemValue(Item.ItemType.Violet) <= 0)
                        return;
                    money = prices[1 + biome % 4];
                    manager.PayItem(Item.ItemType.Violet, 1);
                    break;
                case Item.ItemType.Orange:
                    if (manager.GetItemValue(Item.ItemType.Orange) <= 0)
                        return;
                    money = prices[1 +(1 + biome) % 4];
                    manager.PayItem(Item.ItemType.Orange, 1);
                    break;
                case Item.ItemType.Bleu:
                    if (manager.GetItemValue(Item.ItemType.Bleu) <= 0)
                        return;
                    money = prices[1 + (2 + biome) % 4];
                    manager.PayItem(Item.ItemType.Bleu, 1);
                    break;
                case Item.ItemType.Vert:
                    if (manager.GetItemValue(Item.ItemType.Vert) <= 0)
                        return;
                    money = prices[1 + (3 + biome) % 4];
                    manager.PayItem(Item.ItemType.Vert, 1);
                    break;

            }

            manager.Money += money;

        }

        #endregion
    }
}
