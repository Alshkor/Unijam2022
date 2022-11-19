using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Class mère des objets
/// </summary>
public class Item : MonoBehaviour
{
    #region Enum
    
    public enum ItemType
    {
        Bleu,
        Violet,
        Orange,
        Vert
    };
    
    #endregion

    #region Attributes

    [SerializeField] private ItemType type = ItemType.Orange;
    private int value = 1;
    private bool taken = false;

    #endregion

    #region Mono Behaviour handlers

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.CompareTag("Player") && !taken)
        {
            ItemManager.Instance.GainItem(type, value);
            taken = true;
            StartCoroutine(Disappear());
        }
        else
        {
            Debug.Log($"Item {transform.name} is in contact of gameobject : {other.gameObject.name}");
        }
    }

    #endregion

    #region Public Methods

    

    #endregion

    #region Private Methods

    IEnumerator Disappear(float time = 0)
    {
        yield return (time == 0 ? null : time);
        Destroy(gameObject);
    }

    #endregion
    
    
}
