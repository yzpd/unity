using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class SecondButton : MonoBehaviour {

    public GameObject FourthBtnObj1;
    public GameObject FourthBtnObj2;
    public GameObject FourthBtnObj3;
    public GameObject FourthBtnObj4;
    public GameObject FourthBtnObj5;
    public GameObject FourthBtnObj6;
    public GameObject FourthBtnObj7;
    public GameObject FourthBtnObj8;

    public List<GameObject> FourthBtnList = new List<GameObject>();

    public InputField FourthInput1;
    public InputField FourthInput2;
    public InputField FourthInput3;
    public InputField FourthInput4;
    public InputField FourthInput5;
    public InputField FourthInput6;
    public InputField FourthInput7;
    public InputField FourthInput8;

    public List<InputField> FourthInputList = new List<InputField>();

    public GameObject FifPanel1;
    public GameObject FifPanel2;
    public GameObject FifPanel3;
    public GameObject FifPanel4;
    public GameObject FifPanel5;
    public GameObject FifPanel6;
    public GameObject FifPanel7;
    public GameObject FifPanel8;

    public List<GameObject> FifthPanelList = new List<GameObject>();

    public GameObject SecBtn;//二级按键
    public GameObject SecBtnEdit;//二级Edit按键
    public GameObject ThirdAdd;//三级Add按键
    public GameObject SubPanel;//次面板
    public InputField SecName;
    public InputField SecTitle;
    public InputField SecIntro;
    public InputField ThirdName;//三级按键name
    public InputField ThirdTitle;//三级按键title
    public InputField ThirdIntro;//三级按键introduce
    public string Name = "name";
    public string title = "title";
    public string introduce = "introduce";

    public Text BtnBNum;
    public string B;
    public int b;

    public int FourthBtnNum = 0;

    public Num ButtonNum;
    public ButtonN N;

    public line Line;
    public GameObject StartBtnObj;
    int segmentNum = 41;

    float x = 20.8f;
    float delat_y_R = 0;
    float delat_y_L = 0;
    float y = 0;

    // Use this for initialization
    void Start () {
        FourthBtnList = new List<GameObject>{ FourthBtnObj1, FourthBtnObj2, FourthBtnObj3, FourthBtnObj4, FourthBtnObj5, FourthBtnObj6,
                                           FourthBtnObj7, FourthBtnObj8 };
        FourthInputList = new List<InputField>{ FourthInput1, FourthInput2, FourthInput3, FourthInput4, FourthInput5, FourthInput6,
                                                FourthInput7, FourthInput8};

        FifthPanelList = new List<GameObject> { FifPanel1, FifPanel2, FifPanel3, FifPanel4, FifPanel5, FifPanel6, FifPanel7, FifPanel8 };

        B = BtnBNum.text;
        
        Button btn = SecBtn.GetComponent<Button>();

        btn.onClick.AddListener(delegate {

            b = int.Parse(B) + ButtonNum.a * 10;
            int j = b * 10 + 1;
            int k = (b + 1) * 10 - 1;

            SecTitle.interactable = true;//初始化title组件
            JsonData BtnAttribute1 = Load.LoadButton();
            if (BtnAttribute1[b][1].ToString() != title)
                SecTitle.interactable = false;
            ButtonNum.b = b;
            ButtonNum.c = 0;
            SecBtnEdit.transform.SetAsLastSibling();
            
            SecName.text = BtnAttribute1[b][0].ToString();
            SecTitle.text = BtnAttribute1[b][1].ToString();
            SecIntro.text = BtnAttribute1[b][2].ToString();

            for (int i = 0; i < 8; i++)
            {
                FifthPanelList[i].transform.localScale = new Vector3(0, 0, 0);
            }

            N.BtnN[b]++;
            if (N.BtnN[b] == 2)
            {
                N.BtnN[b] = 0;
                SubPanel.transform.SetAsLastSibling();
                ThirdAdd.transform.SetAsLastSibling();

                JsonData BtnAttribute2 = Load.LoadButton();
                ThirdName.text = BtnAttribute2[b][0].ToString();
                ThirdTitle.text = BtnAttribute2[b][1].ToString();
                ThirdIntro.text = BtnAttribute2[b][2].ToString();

                int m = 0;
                for (int i = j; i < k; i++)
                {
                    FourthInputList[m].text = BtnAttribute2[i][0].ToString();
                    if (FourthInputList[m].text != Name)
                    {
                        FourthInputList[m].interactable = false;
                        FourthInputList[m].transform.SetAsFirstSibling();
                    }
                    else
                    {
                        FourthInputList[m].interactable = true;
                        FourthInputList[m].transform.SetAsLastSibling();
                    }
                    m++;
                }

                JsonData BtnNumber = Load.LoadBtnNum();
                FourthBtnNum = int.Parse(BtnNumber[b][0].ToString());
                for (int i = 0; i < 8; i++)
                {
                    FourthBtnList[i].transform.localScale = new Vector3(0, 0, 0);
                }
                /*四级按键显示初始化*/
                Vector3[] path = new Vector3[FourthBtnNum];
                if (FourthBtnNum <= 4)
                {
                    delat_y_R = (100 - 10 * FourthBtnNum) / (FourthBtnNum + 1);
                }
                else
                {
                    delat_y_R = 12f;
                    int K = FourthBtnNum;
                    K = K - 4;
                    delat_y_L = (100 - 10 * K) / (K + 1);
                }
                for (int i = 0; i < FourthBtnNum; i++)
                {
                    FourthBtnList[i].transform.localScale = new Vector3(0.13f, 0.1f, 0);
                    if (i < 4)
                    {
                        x = 20.8f;
                        y = 50 - delat_y_R * (i + 1) - 10 * i - 5;//此y都是i，j从0开始算的
                        path[i] = new Vector3(x, y, 0);
                    }
                    else if (i < 8)
                    {
                        x = -20.8f;
                        int J = i;
                        J = J - 4;
                        y = 50 - delat_y_L * (J + 1) - 10 * J - 5;
                        path[i] = new Vector3(x, y, 0);
                    }
                    FourthBtnList[i].transform.localPosition = path[i];

                    Line.Dline(StartBtnObj, FourthBtnList[i], segmentNum);
                }
            }
        });

        Button btnEdit = SecBtnEdit.GetComponent<Button>();
        btnEdit.onClick.AddListener(delegate {
            SecName.interactable = true;
            SecName.transform.SetAsLastSibling();
            SecTitle.interactable = true;
        });

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
