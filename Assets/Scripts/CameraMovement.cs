using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region public Attribute

    public float speedCamera=1;

    private static float _speedCameraS;
    public static float SpeedCamera => _speedCameraS;
    #endregion

    #region Monobehavior Callback

    private void Start()
    {
        _speedCameraS = speedCamera;
        GameManager.Instance.OnLoad();
        GameManager.Instance.OnNewLevel += () => UpdateSpeed(0.5f);
    }

    public void UpdateSpeed(float val)
    {
        speedCamera += 0.5f;
        _speedCameraS = speedCamera;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right*(speedCamera*Time.deltaTime));
        
    }

    #endregion
}
