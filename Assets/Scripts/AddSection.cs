using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSection : MonoBehaviour
{

    #region privateField

    private int layerSection;

    #endregion

    #region Monobehavior Callback

    private void Awake()
    {
        layerSection = LayerMask.NameToLayer("Section");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == layerSection)
        {
            GameManager.Instance.SectionGenerator.NewSection();
        }
    
    }

    #endregion
}
