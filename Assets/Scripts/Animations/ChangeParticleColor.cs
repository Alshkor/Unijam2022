using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParticleColor : MonoBehaviour
{
    private ParticleSystem _system;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnNewLevel += ChangeSystemColor;
    }

    void ChangeSystemColor()
    {
        ParticleSystem.MainModule main = _system.main;
        main.startColor = new ParticleSystem.MinMaxGradient(GameManager.Instance.getColor());
    }
    
    
}
