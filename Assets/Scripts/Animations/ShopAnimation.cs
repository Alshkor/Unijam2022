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

        _renderer = GetComponent<ParticleSystemRenderer>();
        
        switch (GameManager.Instance.biome)
        {  
            case 0:
                _renderer.mesh = orange;
                main.startColor = new ParticleSystem.MinMaxGradient(new Color(196,156,0));
                break;
            case 1: 
                _renderer.mesh = vert;
                main.startColor = new ParticleSystem.MinMaxGradient(new Color(	30,162,0));
                break;
            case 2:
                _renderer.mesh = blue;
                main.startColor = new ParticleSystem.MinMaxGradient(new Color(0,40,	162));
                break;
            case 3:
                _renderer.mesh = murasaki;
                main.startColor = new ParticleSystem.MinMaxGradient(new Color(	151,0,119));
                break;
        }
    }
}
