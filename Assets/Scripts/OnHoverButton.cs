using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private UnityEvent OnHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHover.Invoke();
    }
}
