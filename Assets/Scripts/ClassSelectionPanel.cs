using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ClassSelectionPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouse_over = false;
    void Update()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        gameObject.GetComponent<Image>().color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        gameObject.GetComponent<Image>().color = Color.white;
    }
}