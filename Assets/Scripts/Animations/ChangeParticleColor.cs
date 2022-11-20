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
        ParticleSystem.MainModule main = _system.main;
        main.startColor = new ParticleSystem.MinMaxGradient(GameManager.Instance.getColor());
    }

    void ChangeSystemColor()
    {
    }
    
    
}
