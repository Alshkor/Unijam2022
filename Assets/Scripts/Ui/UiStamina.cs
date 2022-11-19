using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class UiStamina : Singleton<UiStamina>
    {
        [SerializeField] private Slider staminaBar;


        private void Start()
        {
            UpdateStaminaBar(GameManager.Instance.PlayerStamina, GameManager.Instance.MaxStamina);
        }

        public void UpdateStaminaBar(float current, float max)
        {
            staminaBar.value = current / max;
        }
    }
}
