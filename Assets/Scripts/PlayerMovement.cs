using Interactables;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D character;
    public float max_move_speed;
    public float jump_speed;
    public Transform ground_check_left;
    public Transform ground_check_right;
    public Vector2 jump_force;
    public Animator player_animator;
    public SpriteRenderer player_renderer;
    public float time_accelerate;
    public SoundHandler sound_handler;

    public bool able_to_climb=false;
    public float climbing_speed;
    public PlatformEffector2D one_way_platform_effector;
    public Vector2 world_mouse_pos;
    public MineASprite mine_a_sprite;

    private Vector2 _screen_mouse_Pos;
    private float _acceleration;
    private bool _jump;
    private Vector2 _add_jump_force;
    private Vector2 _move_input_;
    private Vector2 _speed;
    private bool _is_grounded_;
    private bool _was_on_air;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _pauseUI;
    void Awake()
    {
        Application.targetFrameRate = 70;
        _is_grounded_ = true;
        _acceleration = max_move_speed / time_accelerate;
        _was_on_air = false;
        transform.parent = null;
    }

    public void InputMove(Vector2 value)
    {
        _move_input_ = value;
    }

    public void InputJump(float value)
    {
        float val = value;
        _jump = val > 0;
    }
    public void InputMousePos(Vector2 value)
    {
        _screen_mouse_Pos = value;
        world_mouse_pos = _camera.ScreenToWorldPoint(_screen_mouse_Pos);
    }
    public void InputClique()
    {
        if (Inventory.Instance.HasPioche())
        {
            sound_handler.Play_dig();
        }
    }

    public void InputCliqueRelease()
    {
        sound_handler.Stop_dig();
    }

    public void InputCliqueHold()
    {
        if (Inventory.Instance.HasPioche())
        {
            if (mine_a_sprite.destroy_tile_from_pos(world_mouse_pos))
            {
                Debug.LogError("casse");
                Inventory.Instance.NbUtilisationPioche--;
                sound_handler.Stop_dig();
                sound_handler.Play_destroy_rock();
            }
        }
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
        XSpeedAccelerated(_move_input_.x);
        player_animator.SetFloat("Xspeed", Mathf.Abs(_speed.x));
        player_animator.SetBool("is_grounded", _is_grounded_);
        if (!_is_grounded_ && !_was_on_air)
        {
            _was_on_air = true;
        }
        if(_is_grounded_ && _was_on_air)
        {
            _was_on_air = false;
            sound_handler.Play_jumpOnGround();

        }
        if (_speed.x != 0)
        {
            player_renderer.flipX = (_speed.x < 0);
            if (_is_grounded_)
            {
                sound_handler.Play_walk();
            }
            else
            {
                sound_handler.Stop_walk();
            }
        }
        else
        {
            sound_handler.Stop_walk();
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
        if (_move_input_.y > 0.1 && able_to_climb )
        {
            _speed.y = climbing_speed;
        }
        if (one_way_platform_effector != null)
        {
            if (_move_input_.y < -0.1)
            {
                one_way_platform_effector.surfaceArc = 0f;
            }
            else
            {
                if (one_way_platform_effector.surfaceArc == 0f)
                {
                    one_way_platform_effector.surfaceArc = 180f;
                }
            }
        }
        character.velocity = _speed;
        player_animator.SetFloat("Yspeed", _speed.y);
    }

    public void XSpeedAccelerated(float xSpeed)
    {
        if (xSpeed == 0)
        {
            _speed.x=0;
        }
        else
        {
            if (xSpeed * _speed.x < 0)
            {
                _speed.x = 0;
            }
            else
            {
                _speed.x += xSpeed * _acceleration * Time.deltaTime;
                if (_speed.x > 0)
                {
                    _speed.x = Mathf.Min(_speed.x, max_move_speed);
                }
                else
                {
                    _speed.x = Mathf.Max(_speed.x, -max_move_speed);
                }
            }
        }

    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Climbable")
        {
            able_to_climb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Climbable")
        {
            able_to_climb = false;
        }
    }*/
}

