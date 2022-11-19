using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    #region Attribute

    private int _playerLayer;
    
    #endregion
    
    #region Monobehavior Callback

    private void Awake()
    {
        _playerLayer= LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _playerLayer)
        {
            Player player=col.GetComponent<Player>();
            player.KillPlayer();
        }
    }

    #endregion
}
