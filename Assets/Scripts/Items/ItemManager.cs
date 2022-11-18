using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton gérant les objets du joueur, c'est à dire son argent
/// </summary>
public class ItemManager : Singleton<ItemManager>
{
    #region Attributes

    /// <summary>
    /// Les objets obtenus par le joueur
    /// <param name="Item.ItemType">Le type de l'objet</param>
    /// <param name="int">La quantité possédée</param>
    /// </summary>
    private Dictionary<Item.ItemType, int> items;

    #endregion

    #region Mono Behaviour

    void Start()
    {
        items = new Dictionary<Item.ItemType, int>();
    }

    #endregion
    
    #region Public Methods

    /// <summary>
    /// Getter d'item permettant de récupérer la quantité possédée d'un objet
    /// </summary>
    /// <param name="type">Le type dont on souhaite récupérer la quantité</param>
    /// <returns></returns>
    public int GetItemValue(Item.ItemType type)
    {
        if (items.ContainsKey(type))
        {
            return items[type];
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Fonction permettant d'ajouter des ressources au joueur
    /// </summary>
    /// <param name="type">Le type d'objet</param>
    /// <param name="quantity">La quantité dont on augmente le joueur</param>
    public void GainItem(Item.ItemType type, int quantity)
    {
        if (items.ContainsKey(type))
        {
            items[type] += quantity;
        }
        else
        {
           items.Add(type, quantity);
        }
    }

    #endregion

    #region Private Methods

    

    #endregion
}
