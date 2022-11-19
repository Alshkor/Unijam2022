using System;
using UI;
using UnityEngine;

namespace Ui
{
    public class UiManager : Singleton<UiManager>
    {
        #region Attributes

        public CancelableUi currentUi;
        [SerializeField] CreditsMenu creditmenu;
        
        #endregion

        #region Public methods

        public void Cancel()
        {
            if(currentUi != null)
                currentUi.Cancel();
            if (creditmenu != null)
                creditmenu.retourMenu();
        }

        #endregion
    }
}
