using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenu : CancelableUi
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button creditButton;
        [SerializeField] private string mainScene;
        [SerializeField] private string creditsScene;

        public override void Cancel()
        {
            
        }
        
        
        private void OnEnable()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(playButton.gameObject);
        }

        public override void SetButtonClickEvent()
        {
            cancelButton.onClick.AddListener(() => Application.Quit());
            playButton.onClick.AddListener(() => SceneManager.LoadScene(mainScene));
            creditButton.onClick.AddListener(OpenCredit );
        }


        private void OpenCredit()
        {
            SceneManager.LoadScene(creditsScene);
        }
    }
}
