using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class ThirdButton : MonoBehaviour
{

    public GameObject fourthButton1;
    public GameObject fourthButton2;
    public GameObject fourthButton3;
    public GameObject fourthButton4;
    public GameObject fourthButton5;
    public GameObject fourthButton6;
    public GameObject fourthButton7;
    public GameObject fourthButton8;

    public GameObject btnObj;//三级按键
    public GameObject btnAddObj;//三级按键对应的三级add按键

    float x = 20.8f;
    float delat_y_R = 0;
    float delat_y_L = 0;
    float y = 0;
    List<GameObject> fourthButtonList = new List<GameObject>();

    public Num ButtonNum;

    public GameObject ResearchPanel;

    public line Line;
    public GameObject StartBtnObj;

    int segmentNum = 41;
    // Use this for initialization
    void Start()
    {
        Button btn = btnObj.GetComponent<Button>();
        Button btnAdd = btnAddObj.GetComponent<Button>();
        fourthButtonList = new List<GameObject> { fourthButton1, fourthButton2, fourthButton3, fourthButton4, fourthButton5,
                                                  fourthButton6, fourthButton7, fourthButton8 };

        btnAddObj.transform.SetAsFirstSibling();

        btn.onClick.AddListener(delegate ()
        {
            ButtonNum.c = 0;//可以改intro地位和对应的二级按键一样
            btnAddObj.transform.SetAsLastSibling();
        });

        btnAdd.onClick.AddListener(delegate ()
        {
            Line.Delete();

            ResearchPanel.SetActive(false);

            JsonData BtnNum = Load.LoadBtnNum();
            int fourthButtonNum = int.Parse(BtnNum[ButtonNum.b][0].ToString());//四级按键的数量
            if (fourthButtonNum < 8)
            {
                fourthButtonNum+=1;
                BtnNum[ButtonNum.b][0] = fourthButtonNum.ToString();
                Save.SaveBtnNum(BtnNum);
            }

             Vector3[] path = new Vector3[fourthButtonNum];
             if (fourthButtonNum <= 4)
             {
                 delat_y_R = (100 - 10 * fourthButtonNum) / (fourthButtonNum + 1);
             }
             else
             {
                 delat_y_R = 12f;
                 int k = fourthButtonNum;
                 k = k - 4;
                 delat_y_L = (100 - 10 * k) / (k + 1);
             }
             for (int i = 0; i < fourthButtonNum; i++)
             {
                 fourthButtonList[i].transform.localScale = new Vector3(0.13f, 0.1f, 0);
                 if (i < 4)
                 {
                     x = 20.8f;
                     y = 50 - delat_y_R * (i + 1) - 10 * i - 5;//此y都是i，j从0开始算的
                     path[i] = new Vector3(x, y, 0);
                 }
                 else if (i < 8)
                 {
                     x = -20.8f;
                     int j = i;
                     j = j - 4;
                     y = 50 - delat_y_L * (j + 1) - 10 * j - 5;
                     path[i] = new Vector3(x, y, 0);
                 }
                 fourthButtonList[i].transform.localPosition = path[i];

                 Line.Dline(StartBtnObj, fourthButtonList[i], segmentNum);
             }

         });
    }
}
