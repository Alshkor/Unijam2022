using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tilemapscript : MonoBehaviour
{

    private Color colorplatform;
    private Color colortochange;
    // Start is called before the first frame update
    void Start()
    {
        colorplatform = GameManager.Instance.getColor();
        gameObject.GetComponent<Tilemap>().color = colorplatform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
