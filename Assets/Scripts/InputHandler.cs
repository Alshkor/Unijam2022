using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    #region attribute
    
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
}
