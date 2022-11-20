using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region SerializedField
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] private Transform groundCheckRight;
    [SerializeField] private Rigidbody2D character;
    [SerializeField] private AudioSource audioSfx;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioSource runAudio;
    #endregion

    public float sprintSpeed = 0.5f;
    public bool canSprint = true;
    public float jumpSpeed;
    
    public Vector2 jumpForce;
    [SerializeField] private Animator animator;

    #region Priavate Attribute

    private bool _sprintInput;
    private Vector2 _speed;
    private bool _jumpInput;
    private Vector2 _addJumpForce;
    private bool _isGrounded;
    private bool _wasOnAir;
    private bool _isSprinting;

    #endregion

    
    void Awake()
    {
        Application.targetFrameRate = 70;
        _isGrounded = true;
        _wasOnAir = false;
        _speed=Vector2.zero;
    }
    
    public void InputJump(float value)
    {
        _jumpInput = value > 0;
    }
    public void InputSprint(float value)
    {
        _sprintInput = value > 0;
    }
    
    
    void FixedUpdate()
    {
        _isGrounded = Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position,LayerMask.GetMask("Default"));
        MovePlayer();
    }

    void MovePlayer()
    {
        if (!_isGrounded && !_wasOnAir)
        {
            _wasOnAir = true;
        }

        if (_isGrounded && _wasOnAir)
        {
            _wasOnAir = false;
        }

        if (_jumpInput)
        {
            if (_isGrounded && _speed.y<1)
            {
                _speed.y = jumpSpeed;
                audioSfx.clip = jumpSound;
                audioSfx.Play();
                animator.SetTrigger("Jump");
            }
            else
            {
                _speed.y = character.velocity.y;
                character.AddForce(jumpForce);
            }
        }
        else
        {
            _addJumpForce = Vector2.zero;
            _speed.y = character.velocity.y;
        }

        if (_sprintInput && GameManager.Instance.PlayerStamina>0)
        {
            _speed.x = sprintSpeed;
            GameManager.Instance.PlayerStamina -= Time.deltaTime;
            if (!_isSprinting)
            {
                runAudio.Play();
                _isSprinting = true;
            }
        }
        else
        {
            if (_isSprinting)
            {
                runAudio.Stop();
                _isSprinting = false;
            }
            _isSprinting = false;
            _speed.x = 0;
        }
        animator.SetFloat("Speed", _speed.x + CameraMovement.SpeedCamera);
        character.velocity = _speed;
    }
}

