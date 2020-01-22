using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public line Line;
    public Text text1;
    public string C;
    public int c;
    public int start;
    public int end;
    public int segmentNum = 41;

    void Start()
    {
        C = text1.text;
        c = int.Parse(C);
        start = (c - 1) * ( segmentNum - 1 );
        end = c * (segmentNum - 1) - 1;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Line.ChangeColorBlue(start, end);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Line.ChangeColorGrey(start, end);
    }
    
}
