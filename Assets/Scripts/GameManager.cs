using System.Collections;
using Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region Attributes

    private float _playerStamina = 1.5f;
    private float _maxStamina = 3.0f;

    [SerializeField] private string mainScene;
    [SerializeField] private string mainMenu;
    [SerializeField] private string shopMenu;
    [SerializeField] private string loseMenu;

    public int biome = 0; //Biomes 0, 1, 2, 3

    public SectionGenerator SectionGenerator { get; private set; }
    public override bool UseDontDestroyOnLoad => true;

    public void OnLoad()
    {
        SectionGenerator = FindObjectOfType<SectionGenerator>();
    }

    public Color getColor()
    {
        switch (biome)
        {
            case 0:
                return new Color(0.91f, 0.51f, 0.14f);
            case 1:
                return Color.green;
            case 2:
                return Color.blue;
            case 3:
                return new Color(0.69f, 0.13f, 0.55f);
            default:
                return Color.white;
        }
    }

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

    #region Public Methods

    /// <summary>
    /// Methode appelée pour charger un nouveau niveau
    /// </summary>
    public void LoadNewLevel()
    {
        biome = (biome + 1) % 4; // On change de biome
        OnNewLevel?.Invoke();
        SceneManager.LoadScene(mainScene);
    }


    /// <summary>
    /// Methode appelée pour retourner au menu principal, elle va detruire notemment les Don't destroy on load
    /// </summary>
    public void ReturnToMainMenu()
    {
        //todo ajouter d'autres chose a detruire si jamsi il le faut
        Destroy(ItemManager.Instance.gameObject);
        Destroy(gameObject);
        SceneManager.LoadScene(mainMenu);
    }

    /// <summary>
    /// Methode appelée pour charger la scene du shop
    /// </summary>
    public void GoToShop()
    {
        SceneManager.LoadScene(shopMenu);
    }

    /// <summary>
    /// Methode appel2e pour charger l'écran de défaite
    /// </summary>
    public void Lose()
    {
        SceneManager.LoadScene(loseMenu);
    }
    
    
    public delegate void OnNewLevelEventHandler();
    public event OnNewLevelEventHandler OnNewLevel;
    
    

    #endregion


}
