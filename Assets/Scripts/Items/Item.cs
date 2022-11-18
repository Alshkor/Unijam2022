using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class mère des objets
/// </summary>
public class Item : MonoBehaviour
{
    #region Enum
    
    public enum ItemType
    {
        Coquillage,
        Bois,
        Or
    };
    
    #endregion

    #region Attributes

    [SerializeField] private ItemType type = ItemType.Or;
    private int value = 1;

    #endregion

    #region Mono Behaviour handlers

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Player"))
        {
            ItemManager.Instance.GainItem(type, value);
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

    

    #endregion
    
    
}
