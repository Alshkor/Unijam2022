using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private bool rotate;
    
    
    public bool Rotation{
        set
        {
            if (value && !isRotating)
            {
                isRotating = true;
                StartCoroutine(RotationCoroutine());
            }
            else if(!value && isRotating)
            {
                isRotating = false;
            }
        }
    }

    private bool isRotating;

    private void Start()
    {
        isRotating = true;
        StartCoroutine(RotationCoroutine());
    }


    public void ChangeRotation(bool val)
    {
        if (val && !isRotating)
        {
            isRotating = true;
            StartCoroutine(RotationCoroutine());
        }
        else if(!val && isRotating)
        {
            isRotating = false;
        }
    }
    
    
    IEnumerator RotationCoroutine()
    {
        while (isRotating || rotate)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * rotationAxis.normalized);
            yield return null;
        }
    }
}
