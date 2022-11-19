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
    
}
