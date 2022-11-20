using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimation : MonoBehaviour
{
    private ParticleSystem _system;
    private ParticleSystemRenderer _renderer;
    [SerializeField] private Mesh orange;
    [SerializeField] private Mesh vert;
    [SerializeField] private Mesh blue;
    [SerializeField] private Mesh murasaki;

    // Start is called before the first frame update
    void Start()
    {
        _system = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = _system.main;
        Color col = GameManager.Instance.getColor();
        main.startColor = new ParticleSystem.MinMaxGradient(col);
        _renderer = GetComponent<ParticleSystemRenderer>();
        
        switch (GameManager.Instance.biome)
        {  
            case 0:
                _renderer.mesh = orange;
                break;
            case 1: 
                _renderer.mesh = vert;
                break;
            case 2:
                _renderer.mesh = blue;
                break;
            case 3:
                _renderer.mesh = murasaki;
                break;
        }
    }
}
