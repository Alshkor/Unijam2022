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
        GameManager.Instance.OnNewLevel += () => speedCamera += 0.5f;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right*(speedCamera*Time.deltaTime));
        
    }

    #endregion
}
