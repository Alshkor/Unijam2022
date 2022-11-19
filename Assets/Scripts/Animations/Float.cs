using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Float : MonoBehaviour
{
    [SerializeField] private float addHeight;
    [SerializeField] private float sousHeight;
    [SerializeField] private float speed;
    private Vector3 pos_initial;
    private Vector3 target_pos_add;
    private Vector3 target_pos_sous;
    
    public bool Rotation{
        set
        {
            if (value && !isFloating)
            {
                isFloating = true;
                StartCoroutine(FloatingCoroutine());
            }
            else if(!value && isFloating)
            {
                isFloating = false;
            }
        }
    }

    private bool isFloating;

    private void Start()
    {
        isFloating = true;
        pos_initial = transform.localPosition;
        StartCoroutine(FloatingCoroutine());
        
    }


    public void ChangeFloat(bool val)
    {
        if (val && !isFloating)
        {
            isFloating = true;
            StartCoroutine(FloatingCoroutine());
        }
        else if(!val && isFloating)
        {
            isFloating = false;
        }
    }
    
    
    IEnumerator FloatingCoroutine()
    {
        while (isFloating)
        {
            target_pos_add = pos_initial + Vector3.up * addHeight;
            target_pos_sous = pos_initial - Vector3.up * sousHeight;
            while (isFloating && transform.localPosition.y < target_pos_add.y - 0.3)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, target_pos_add, Time.deltaTime * speed);
                yield return null;
            }
            
            while (isFloating && transform.localPosition.y > target_pos_sous.y + 0.3)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, target_pos_sous, Time.deltaTime * speed);
                yield return null;
            }
            yield return null;
        }
    }
}
