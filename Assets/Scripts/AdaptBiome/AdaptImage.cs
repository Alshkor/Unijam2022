using UnityEngine;
using UnityEngine.UI;

public class AdaptImage : MonoBehaviour
{
    
    private Color colorBiome;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.Instance.biome)
        {
            case 0:
                colorBiome = new Color(0.76f, 0.12f, 0.22f);
                break;
            case 1:
                colorBiome =new Color(0.05f, 0.76f, 0.42f);
                break;
            case 2:
                colorBiome = new Color(0.2f, 0.76f, 0.7f);
                break;
            case 3:
                colorBiome = new Color(0.76f, 0.34f, 0.46f);
                break;
        }
        gameObject.GetComponent<Image>().color = colorBiome;
        

    }


}
