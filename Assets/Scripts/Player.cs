using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    #region PrivateAttribute
    

    #endregion
    #region Monobehavior Callback

    // Start is called before the first frame update
    void Awake()
    {

    }



    #endregion

    #region Public methode

    public void KillPlayer()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    

    #endregion
}
