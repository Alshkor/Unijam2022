using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParticleColor : MonoBehaviour
{
    private ParticleSystem _system;
    private static Color actualColor;
    
    // Start is called before the first frame update
    void Start()
    {
        _system = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = _system.main;
        Color col = GameManager.Instance.getColor();
        main.startColor = new ParticleSystem.MinMaxGradient(col);
    }
   
}
