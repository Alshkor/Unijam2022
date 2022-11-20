using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
    public class SellMenu : CancelableUi
    {
        #region Attributes
        [SerializeField] private Image image;

        [SerializeField] private Button button1;
        [SerializeField] private Button button2;
        [SerializeField] private Button button3;
        [SerializeField] private Button button4;
        
        [SerializeField] private Button buttonSellAll1;
        [SerializeField] private Button buttonSellAll2;
        [SerializeField] private Button buttonSellAll3;
        [SerializeField] private Button buttonSellAll4;

        [SerializeField] private int[] prices; //prix du plus bas au plus haut par ex : [10, 20, 30, 40]
        [SerializeField] private TextMeshProUGUI[] distanceTexts;
        [SerializeField] private TextMeshProUGUI[] priceTexts;
        [SerializeField] private TextMeshProUGUI[] priceAllTexts;

        #endregion
        
        private void OnEnable()
        {
            image.color = GameManager.Instance.getColor();
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(cancelButton.gameObject);
        }


        #region Override Methods

        public override void SetButtonClickEvent()
        {
            cancelButton.onClick.AddListener(Cancel);
            button1.onClick.AddListener(() => Sell(Item.ItemType.Orange));
            button2.onClick.AddListener(() => Sell(Item.ItemType.Vert));
            button3.onClick.AddListener(() => Sell(Item.ItemType.Bleu));
            button4.onClick.AddListener(() => Sell(Item.ItemType.Violet));
            
            buttonSellAll1.onClick.AddListener(() => SellAll(Item.ItemType.Orange));
            buttonSellAll2.onClick.AddListener(() => SellAll(Item.ItemType.Vert));
            buttonSellAll3.onClick.AddListener(() => SellAll(Item.ItemType.Bleu));
            buttonSellAll4.onClick.AddListener(() => SellAll(Item.ItemType.Violet));
            
            SetTexts();
            
        }

        #endregion


        #region Private Methods


        private void SetTexts()
        {
            var types = new[]{Item.ItemType.Orange, Item.ItemType.Vert, Item.ItemType.Bleu, Item.ItemType.Violet};
            
            int biome = GameManager.Instance.biome;
            for (int i = 0; i < 4; i++)
            {
                priceTexts[i].text = prices[(4 - i + biome) % 4] + " CAD";
                priceAllTexts[i].text = prices[(4 - i + biome) % 4]*ItemManager.Instance.GetItemValue(types[i]) + " CAD";
                distanceTexts[i].text = (4 - i + biome) % 4 + "";
            }
        }

        private void Sell(Item.ItemType itemType)
        {
            int biome = GameManager.Instance.biome;
            int money = 0;
            var manager = ItemManager.Instance;

            switch (itemType)
            {
                case Item.ItemType.Orange:
                    if (manager.GetItemValue(itemType) <= 0)
                        return;
                    money = prices[biome % 4];
                    manager.PayItem(itemType, 1);
                    break;
                case Item.ItemType.Vert:
                    if (manager.GetItemValue(itemType) <= 0)
                        return;
                    money = prices[(3 + biome) % 4];
                    manager.PayItem(itemType, 1);
                    break;
                case Item.ItemType.Bleu:
                    if (manager.GetItemValue(itemType) <= 0)
                        return;
                    money = prices[(2 + biome) % 4];
                    manager.PayItem(itemType, 1);
                    break;
                case Item.ItemType.Violet:
                    if (manager.GetItemValue(itemType) <= 0)
                        return;
                    money = prices[(1 + biome) % 4];
                    manager.PayItem(itemType, 1);
                    break;
            }

            manager.Money += money;
            
            SetTexts();
        }


        private void SellAll(Item.ItemType itemType)
        {
            int biome = GameManager.Instance.biome;
            int money = 0;
            var manager = ItemManager.Instance;

            switch (itemType)
            {
                case Item.ItemType.Orange:
                    money = prices[biome % 4] * manager.GetItemValue(itemType);
                    manager.PayItem(itemType, manager.GetItemValue(itemType));
                    break;
                case Item.ItemType.Vert:
                    money = prices[(1 + biome) % 4] * manager.GetItemValue(itemType);
                    manager.PayItem(itemType, manager.GetItemValue(itemType));
                    break;
                case Item.ItemType.Bleu:
                    money = prices[(2 + biome) % 4] * manager.GetItemValue(itemType);
                    manager.PayItem(itemType, manager.GetItemValue(itemType));
                    break;
                case Item.ItemType.Violet:
                    money = prices[(3 + biome) % 4] * manager.GetItemValue(itemType);
                    manager.PayItem(itemType, manager.GetItemValue(itemType));
                    break;
            }
            manager.Money += money;

            SetTexts();
        }

        #endregion
    }
}
