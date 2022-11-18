using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D character;
    public float jump_speed;
    public Transform ground_check_left;
    public Transform ground_check_right;
    public Vector2 jump_force;


    private Vector2 _speed;
    private bool _jump;
    private Vector2 _add_jump_force;
    private bool _is_grounded_;
    private bool _was_on_air;
    
    void Awake()
    {
        Application.targetFrameRate = 70;
        _is_grounded_ = true;
        _was_on_air = false;
        transform.parent = null;
        _speed=Vector2.zero;
    }
    
    public void InputJump(float value)
    {
        float val = value;
        _jump = val > 0;
    }
    
    
    void FixedUpdate()
    {
        _is_grounded_ = Physics2D.Linecast(ground_check_left.position, ground_check_right.position,LayerMask.GetMask("Default"));
        /*if (!_pauseUI.activeSelf)
            Move_player();*/
        Move_player();
    }

    void Move_player()
    {
        if (!_is_grounded_ && !_was_on_air)
        {
            _was_on_air = true;
        }

        if (_is_grounded_ && _was_on_air)
        {
            _was_on_air = false;


        }

        if (_jump)
        {
            if (_is_grounded_ && _speed.y<1)
            {
                _speed.y = jump_speed;
            }
            else
            {
                _speed.y = character.velocity.y;
                character.AddForce(jump_force);

            }
        }
        else
        {
            _add_jump_force = Vector2.zero;
            _speed.y = character.velocity.y;
        }
        character.velocity = _speed;
    }
    
    
}

