using System.Collections;
using System.Collections.Generic;
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
                colorBiome = new Color(195, 31, 57);
                break;
            case 1:
                colorBiome = new Color(195, 31, 57);
                break;
            case 2:
                colorBiome = new Color(195, 31, 57);
                break;
            case 3:
                colorBiome = new Color(195, 31, 57);
                break;
            default:
                break;
        }
        gameObject.GetComponent<Image>().color = colorBiome;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
