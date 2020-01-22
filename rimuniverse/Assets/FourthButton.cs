using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class FourthButton : MonoBehaviour {

    public GameObject fifthButton1;
    public GameObject fifthButton2;
    public GameObject fifthButton3;
    public GameObject fifthButton4;
    public GameObject fifthButton5;
    public GameObject fifthButton6;

    public InputField FifthInput1;
    public InputField FifthInput2;
    public InputField FifthInput3;
    public InputField FifthInput4;
    public InputField FifthInput5;
    public InputField FifthInput6;

    public GameObject btnObj;//四级按键
    public GameObject btnImg;//四级按键的外框
    public GameObject btnEditObj;//四级按键对应的四级edit按键
    public GameObject btnAddObj;//四级按键对应的四级add按键
    public GameObject panel;//五级按键的panel

    public Text BtnCNum;
    public string C;
    public int c;
    public Num ButtonNum;
    public int FifthBtnNum = 0;

    public InputField FourthName;//四级按键name
    public InputField FourthTitle;//四级按键title
    public InputField FourthIntro;//四级按键introduce
    public string Name = "name";
    public string title = "title";
    public string introduce = "introduce";

    List<GameObject> fifthButtonList = new List<GameObject>();
    List<InputField> FifthInputList = new List<InputField>();

    public GameObject ResearchPanel;

    // Use this for initialization
    void Start () {

        Vector3[] path = new Vector3[7];

        Button btn = btnObj.GetComponent<Button>();

        Button btnEdit = btnEditObj.GetComponent<Button>();
        Button btnAdd = btnAddObj.GetComponent<Button>();
        fifthButtonList = new List<GameObject> { btnObj, fifthButton1, fifthButton2, fifthButton3, fifthButton4, fifthButton5,
                                                 fifthButton6 };
        FifthInputList = new List<InputField> { FifthInput1, FifthInput2, FifthInput3, FifthInput4, FifthInput5, FifthInput6};

        C = BtnCNum.text;

        btn.onClick.AddListener(delegate ()
        {
            ResearchPanel.SetActive(false);

            btnEdit.transform.SetAsLastSibling();
            btnAdd.transform.SetAsLastSibling();

            c = int.Parse(C) + ButtonNum.b * 10;
            ButtonNum.c = c;
            ButtonNum.d = 0;
            int j = c * 10 + 1;
            int k = (c + 1) * 10 - 3;

            FourthTitle.interactable = true;//初始化title组件
            JsonData BtnAttribute1 = Load.LoadButton();
            if (BtnAttribute1[c][1].ToString() != title)
                FourthTitle.interactable = false;

            FourthName.text = BtnAttribute1[c][0].ToString();
            FourthTitle.text = BtnAttribute1[c][1].ToString();
            FourthIntro.text = BtnAttribute1[c][2].ToString();

            int m = 0;
            for (int i = j; i < k; i++)
            {
                FifthInputList[m].text = BtnAttribute1[i][0].ToString();
                if (FifthInputList[m].text != Name)
                {
                    FifthInputList[m].interactable = false;
                    FifthInputList[m].transform.SetAsFirstSibling();
                }
                else
                {
                    FifthInputList[m].interactable = true;
                    FifthInputList[m].transform.SetAsLastSibling();
                }
                m++;
            }

            JsonData BtnNumber = Load.LoadBtnNum();
            FifthBtnNum = int.Parse(BtnNumber[c][0].ToString());
            for (int i = 1; i < 7; i++)
            {
                fifthButtonList[i].transform.localScale = new Vector3(0, 0, 0);
            }
            panel.transform.localScale = new Vector3(1.528f, 2.285f, 0);

            path[0] = btnImg.transform.localPosition;//第0位用来存四级按键的位置
            if (path[0].x > 0)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (i < 4)
                        path[i] = new Vector3(-23f, -31f * (i - 2), 0);
                    else if (i < 7)
                        path[i] = new Vector3(23f, -31f * (i - 5), 0);
                }
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if (i < 4)
                        path[i] = new Vector3(23f, -31f * (i - 2), 0);
                    else if (i < 7)
                        path[i] = new Vector3(-23f, -31f * (i - 5), 0);
                }
            }
            for (int i = 1; i <= FifthBtnNum; i++)
            {
                fifthButtonList[i].transform.localScale = new Vector3(0.4f, 0.25f, 0);
                fifthButtonList[i].transform.localPosition = path[i];
            }

        });


        btnEdit.onClick.AddListener(delegate ()
        {
            FourthName.interactable = true;
            FourthTitle.interactable = true;
            FourthName.transform.SetAsLastSibling();
        });

        btnAdd.onClick.AddListener(delegate ()
        {
            path[0] = btnImg.transform.localPosition;//第0位用来存四级按键的位置
            if (path[0].x > 0)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (i < 4)
                        path[i] = new Vector3(-23f, -31f * (i - 2), 0);
                    else if (i < 7)
                        path[i] = new Vector3( 23f, -31f * (i - 5), 0);
                }
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if (i < 4)
                        path[i] = new Vector3( 23f, -31f * (i - 2), 0);
                    else if (i < 7)
                        path[i] = new Vector3(-23f, -31f * (i - 5), 0);
                }
            }
            JsonData BtnNum = Load.LoadBtnNum();
            FifthBtnNum = int.Parse(BtnNum[c][0].ToString());
            if (FifthBtnNum < 6)
            {
                FifthBtnNum++;
                BtnNum[c][0] = FifthBtnNum.ToString();
                Save.SaveBtnNum(BtnNum);
            }
            for (int i = 1; i <= FifthBtnNum; i++)
            {
                fifthButtonList[i].transform.localScale = new Vector3(0.4f, 0.25f, 0);
                fifthButtonList[i].transform.localPosition = path[i];
            }
        });
    }
}
