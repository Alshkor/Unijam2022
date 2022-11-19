using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Classe gerant les elements d'ui qui peuvent soit se fermer, soit permettre un retour arriere vers une autre ui
    /// </summary>
    public class CancelableUi : MonoBehaviour
    {
        #region Attributes
        
        [SerializeField] protected bool hasPreviousMenu;
        [SerializeField] protected CancelableUi previousMenu;
        [SerializeField] protected Button cancelButton;
        
        #endregion

        private void Start()
        {
            SetButtonClickEvent();
        }
        
        #region Protected methods
        
        /// <summary>
        /// Methode appelée pour cancel cette ui 
        /// </summary>
        public virtual void Cancel()
        {
            gameObject.SetActive(false);
            if (!hasPreviousMenu) return;
            UiManager.Instance.currentUi = previousMenu;
            previousMenu.gameObject.SetActive(true);
        }

        /// <summary>
        /// Methode permettant de set les event sur les clicks des bouttons
        /// </summary>
        public virtual void SetButtonClickEvent()
        {
            if(hasPreviousMenu)
                cancelButton.onClick.AddListener(Cancel);
        }

        #endregion
    }
}
