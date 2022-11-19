using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptDegrade : MonoBehaviour
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
                colorBiome =new Color(0.76f, 0.12f, 0.22f);
                break;
            case 2:
                colorBiome = new Color(0.76f, 0.12f, 0.22f);
                break;
            case 3:
                colorBiome = new Color(0.76f, 0.12f, 0.22f);
                break;
            default:
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().color = colorBiome;    
    }
}
