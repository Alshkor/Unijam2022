using UI;

namespace Ui
{
    public class UiManager : Singleton<UiManager>
    {
        #region Attributes

        public CancelableUi currentUi;
        
        #endregion

        #region Public methods

        public void Cancel()
        {
            if(currentUi != null)
                currentUi.Cancel();
        }

        #endregion
    }
}
