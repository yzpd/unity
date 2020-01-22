using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//按下按键特效
public class button6 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject btnImg;
    int color = 0;//color=0原始是灰色，color=1原始是绿色

    public void OnPointerDown(PointerEventData eventData)
    {
        Image Img = btnImg.GetComponent<Image>();
        if (Img.color == new Color((78f / 255), (78f / 255), (78f / 255), 1))
        {
            Img.color = new Color((101f / 255), (101f / 255), (101f / 255), 1);
            color = 0;
        }
        else
        {
            Img.color = new Color((78f / 255), (78f / 255), (78f / 255), 1);
            color = 1;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Image Img = btnImg.GetComponent<Image>();
        if(color == 0)
            Img.color = new Color((78f / 255), (78f / 255), (78f / 255), 1);
        else
            Img.color = new Color(0, (64f / 255), (16f / 255), 1);
    }
}
