using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class LooseManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button returnMainMenuButton;
        
        private void Start()
        {
            scoreText.text = "Score : " + ItemManager.Instance.Money;
            ItemManager.Instance.gameObject.SetActive(false);
            returnMainMenuButton.onClick.AddListener(GameManager.Instance.ReturnToMainMenu);
        }
    }
}
