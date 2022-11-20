using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region public Attribute

    [SerializeField] private float speedCamera=1;
    
    private static float _speedCameraS;

    public static bool _isInit;
    public static float SpeedCamera => _speedCameraS;
    #endregion

    #region Monobehavior Callback

    private void Start()
    {
        if (!_isInit)
            _speedCameraS = speedCamera;
        else
            speedCamera = _speedCameraS;
        GameManager.Instance.OnLoad();
        GameManager.Instance.OnNewLevel += () => UpdateSpeed(0.5f);
        _isInit = true;
    }

    public void UpdateSpeed(float val)
    {
        speedCamera += 1.0f;
        _speedCameraS = speedCamera;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right*(speedCamera*Time.deltaTime));
        
    }

    #endregion
}
