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
        int val = value.Get<int>();
        _playerMovement.InputJump(val);
    }
}
