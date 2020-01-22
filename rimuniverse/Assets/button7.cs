using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//按下按键特效
public class button7 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject btnImg;

    public void OnPointerDown(PointerEventData eventData)
    {
        Image Img = btnImg.GetComponent<Image>();
        Img.color = new Color((78f / 255), (78f / 255), (78f / 255), 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Image Img = btnImg.GetComponent<Image>();
        Img.color = new Color((32f / 255), (32f / 255), (32f / 255), 1);
    }
}