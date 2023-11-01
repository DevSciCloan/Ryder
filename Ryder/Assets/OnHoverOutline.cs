using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverOutline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Outline outline;
        bool hasOutline = gameObject.TryGetComponent<Outline>(out outline);
        if ( hasOutline && gameObject.GetComponent<Button>().interactable)
        {
            outline.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Outline outline;
        bool hasOutline = gameObject.TryGetComponent<Outline>(out outline);
        if ( hasOutline && gameObject.GetComponent<Button>().interactable)
        {
            outline.enabled = false;
        }
    }
}
