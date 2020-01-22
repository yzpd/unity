using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
public class FirstBtnAdd : MonoBehaviour {
    public Num ButtonNum;

    public GameObject secondButton1;
    public GameObject secondButton2;
    public GameObject secondButton3;
    public GameObject secondButton4;
    public GameObject secondButton5;
    public GameObject secondButton6;
    public GameObject secondButton7;
    public GameObject secondButton8;
    public GameObject secondButton9;

    List<GameObject> secondButtonList = new List<GameObject>();

    public void Start()
    {
        secondButtonList = new List<GameObject> { secondButton1, secondButton2, secondButton3, secondButton4, secondButton5,
                                                  secondButton6, secondButton7, secondButton8, secondButton9 };
        //GameObject.Find("Line").SendMessage("Dline");
    }

    public void OnClick()
    {
        int a = ButtonNum.a;
        /*读取保存按键数量处*/
        JsonData BtnNum = Load.LoadBtnNum();
        int SecondButtonNum = int.Parse(BtnNum[a][0].ToString());//二级按键的数量
        if (SecondButtonNum < 9)
        {
            SecondButtonNum += 1;
            BtnNum[a][0] = SecondButtonNum.ToString();
            Save.SaveBtnNum(BtnNum);
        }

        for (int i = 0; i < SecondButtonNum; i++)
        {
            secondButtonList[i].transform.localScale = new Vector3(0.15f, 0.15f, 0);
        }
    }
}
