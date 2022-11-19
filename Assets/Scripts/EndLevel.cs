using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    private int _layerPlayer;

    private void Awake()
    {
        _layerPlayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _layerPlayer)
        {
            GameManager.Instance.GoToShop();
        }
    }
}
