
using Ui;

public class GameManager : Singleton<GameManager>
{
    #region Attributes

    private float _playerStamina = 1.5f;
    private float _maxStamina = 3.0f;
    public int biome = 0;

    public override bool UseDontDestroyOnLoad => true;

    public float PlayerStamina
    {
        get => _playerStamina;
        set
        {
            if (value < 0)
                _playerStamina = 0;
            else if (value > _maxStamina)
                _playerStamina = _maxStamina;
            else
                _playerStamina = value;
            
            UiStamina.Instance.UpdateStaminaBar(_playerStamina, _maxStamina);
        }
    }
    
    public float MaxStamina
    {
        get => _maxStamina;
        set
        {
            if (value < 0)
                return;

            _maxStamina = value;
            UiStamina.Instance.UpdateStaminaBar(_playerStamina, _maxStamina);
        }
    }

    #endregion




}
