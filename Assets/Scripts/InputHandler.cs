using System.Collections;
using System.Collections.Generic;
using Ui;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    #region attribute
    [SerializeField] private PauseMenu pauseMenu;   
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] private SoundMuter soundMuter;
    

    #endregion
    void OnJump(InputValue value)
    {
        float val = value.Get<float>();
        _playerMovement.InputJump(val);
    }
    void OnSprint(InputValue value)
    {
        float val = value.Get<float>();
        _playerMovement.InputSprint(val);
    }

    void OnPause(InputValue val)
    {
        pauseMenu.Pause();
    }

    
    /*void OnEndLevel()
    {
        GameManager.Instance.GoToShop();
    }
    
    void OnOrange()
    {
        ItemManager.Instance.GainItem(Item.ItemType.Orange, 1);
    }
    
    void OnViolet()
    {
        ItemManager.Instance.GainItem(Item.ItemType.Violet, 1);
    }
    
    void OnBleu()
    {
        ItemManager.Instance.GainItem(Item.ItemType.Bleu, 1);
    }
    
    void OnVert()
    {
        ItemManager.Instance.GainItem(Item.ItemType.Vert, 1);
    }*/

    void OnMuteSfx()
    {
        soundMuter.ToggleSfx();
    }

    void OnMuteMusic()
    {
        soundMuter.ToggleMusic();
    }
    
}
