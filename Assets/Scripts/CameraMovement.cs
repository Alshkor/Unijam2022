using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region public Attribute

    public float speedCamera=1;

    
    #endregion

    #region Monobehavior Callback

    private void Start()
    {
        GameManager.Instance.OnLoad();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right*(speedCamera*Time.deltaTime));
        
    }

    #endregion
}
