using UnityEngine;
using UnityEngine.UI;

public class AdaptImage : MonoBehaviour
{

    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject vert;
    [SerializeField] private GameObject bleu;
    [SerializeField] private GameObject violet;
    [SerializeField] private RuleTile ruleTile;
    private Color colorBiome;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.Instance.biome)
        {
            case 0:
                colorBiome = new Color(0.76f, 0.12f, 0.22f);
                ruleTile.m_DefaultGameObject = orange;
                break;
            case 1:
                colorBiome =new Color(0.76f, 0.12f, 0.22f);
                ruleTile.m_DefaultGameObject = vert;
                break;
            case 2:
                colorBiome = new Color(0.76f, 0.12f, 0.22f);
                ruleTile.m_DefaultGameObject = bleu;
                break;
            case 3:
                colorBiome = new Color(0.76f, 0.12f, 0.22f);
                ruleTile.m_DefaultGameObject = violet;
                break;
        }
        gameObject.GetComponent<Image>().color = colorBiome;
        

    }


}
