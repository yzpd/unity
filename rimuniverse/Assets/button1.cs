using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class button1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject btnImg;//一级按键的Image

    public void OnPointerDown(PointerEventData eventData)
    {
        Image Img = btnImg.GetComponent<Image>();
        Img.color = new Color((32f / 255), (33f / 255), (34f / 255), 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Image Img = btnImg.GetComponent<Image>();
        Img.color = new Color((56f / 255), (56f / 255), (56f / 255), 1);
    }
}
