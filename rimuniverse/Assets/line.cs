using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class line : MonoBehaviour {

    //public float lineWidth = 1f;
    public GameObject SubPanel;
    List<Image> LineList = new List<Image>();
    /*
    public class LList {
        public List<Image>[] llist;
    }
    */

    public List<Image> Dline (GameObject btnStart, GameObject btnEnd, int segmentNum) {

        Vector3 startPos = btnStart.transform.localPosition;
        Vector3 endPos = btnEnd.transform.localPosition;
        Vector3 controlPos = new Vector3(0, 0, 0); 
        
        if (endPos.y != 0)
            controlPos = new Vector3(startPos.x, endPos.y, 0);
        //if(startPos.y != 0)
            //controlPos = new Vector3(endPos.x, startPos.y, 0);
        else
            controlPos = new Vector3(endPos.x, endPos.y, 0);
        //      GameObject.Find("BezierUtils").SendMessage("GetBeizerList");
        Vector3[]  path = BezierUtils.GetBeizerList(startPos, controlPos, endPos, segmentNum);
        
        //      drawline(startPos, path[1]);
        for (int i = 1; i < segmentNum; i++)
        {
            Image lineObjImg = Drawline(path[i], path[i+1]);
            LineList.Add(lineObjImg);
        }

        return LineList;
    }
    
    public void Delete()
    {
        for (int i = 0; i < LineList.Count; i++)
            Destroy(LineList[i].gameObject);
        LineList = new List<Image>();
    }

    public void ChangeColorBlue(int start, int end)
    {
        for (int i = start; i < end; i++)
            LineList[i].color = new Color((38f / 255), (169f / 255), 1, 1);
    }

    public void ChangeColorGrey(int start, int end)
    {
        for (int i = start; i < end; i++)
            LineList[i].color = new Color((126f / 255), (126f / 255), (126f / 255), 1);
    }

    Image Drawline(Vector3 startPos, Vector3 endPos)
    {
        GameObject lineObj = new GameObject("LineObj");
        lineObj.SetActive(false);       
        RectTransform lineObjRT;
        lineObjRT = lineObj.AddComponent<RectTransform>();
        lineObjRT.pivot = new Vector2(0, 0.5f);
        lineObjRT.SetParent(transform);
        Image lineObjImg = lineObj.AddComponent<Image>();
        lineObjImg.transform.SetParent(SubPanel.transform);
        lineObjImg.transform.localScale = new Vector3(1, 1, 1);
        lineObjImg.color = new Color((126f / 255), (126f / 255), (126f / 255), 1);
        //lineObjImg.color = Color.red;
        lineObjImg.raycastTarget = false;
        lineObjRT.localPosition = startPos;
        Vector3 durationPos = endPos - startPos;
        lineObjRT.sizeDelta = new Vector2(durationPos.magnitude, 0.5f);
        //lineObjRT.localPosition = new Vector3(0,0,0);
        //lineObjRT.sizeDelta = new Vector2(100,5);
        float angle = Mathf.Atan2(durationPos.y, durationPos.x) * Mathf.Rad2Deg;
        lineObjRT.localRotation = Quaternion.Euler(0, 0, angle);
        lineObj.SetActive(true);
        //lineObj.transform.SetAsFirstSibling();

        return lineObjImg;
    }
}
