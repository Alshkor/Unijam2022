using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    #region PrivateAttribute

    [SerializeField] private UnityEvent onDeath;
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
        onDeath.Invoke();
        StartCoroutine(DestroyAfter(2));
    }

    IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.Lose();
    }
    

    #endregion
}
