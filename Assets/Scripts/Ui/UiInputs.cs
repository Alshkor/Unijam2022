using UnityEngine;

namespace Ui
{
    public class UiInputs : MonoBehaviour
    {
        private void OnCancel()
        {
            UiManager.Instance.Cancel();
        }
    }
}
