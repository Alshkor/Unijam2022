using System;
using Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region Attributes

    private float _playerStamina = 3.0f;
    private float _maxStamina = 3.0f;

    [SerializeField] private string mainScene;
    [SerializeField] private string mainMenu;
    [SerializeField] private string shopMenu;
    [SerializeField] private string loseMenu;
    
    //private RuleTile _ruleTile;
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject vert;
    [SerializeField] private GameObject bleu;
    [SerializeField] private GameObject violet;

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
                return new Color(39/255f, 111/255f, 8/255f);
            case 2:
                return new Color(16/255f, 19/255f, 91/255f);
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
        //_ruleTile = Resources.Load<RuleTile>("ItemJaune");
        biome = (biome + 1) % 4; // On change de biome
        /*switch (biome)
        {
            case 0:
                _ruleTile.m_DefaultGameObject = orange;
                break;
            case 1:
                _ruleTile.m_DefaultGameObject = vert;
                break;
            case 2:
                _ruleTile.m_DefaultGameObject = bleu;
                break;
            case 3:
                _ruleTile.m_DefaultGameObject = violet;
                break;
        }*/
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

    public GameObject GetItemGameObject()
    {

        switch (biome)
        {
            case 0:
                return orange;
            case 1:
                return vert;
            case 2:
                return bleu;
            case 3:
                return violet;
            default:
                return orange;
        }
    }


    private void Start()
    {
        Application.targetFrameRate = 80;
    }

    #endregion


}
