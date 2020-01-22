using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class FirstButton : MonoBehaviour {
    public GameObject SecBtnObj1;
    public GameObject SecBtnObj2;
    public GameObject SecBtnObj3;
    public GameObject SecBtnObj4;
    public GameObject SecBtnObj5;
    public GameObject SecBtnObj6;
    public GameObject SecBtnObj7;
    public GameObject SecBtnObj8;
    public GameObject SecBtnObj9;

    public InputField SecInput1;
    public InputField SecInput2;
    public InputField SecInput3;
    public InputField SecInput4;
    public InputField SecInput5;
    public InputField SecInput6;
    public InputField SecInput7;
    public InputField SecInput8;
    public InputField SecInput9;

    public GameObject FirstBtn;//一级按键
    public GameObject FirstBtnAdd;//一级Add按键
    public GameObject FirstBtnEdit;//一级Edit按键
    public GameObject MasterPanel;//主面板
    public InputField FirstName;
    public InputField FirstTitle;
    public InputField FirstIntro;
    public string Name = "name";
    public string title = "title";
    public string introduce = "introduce";

    public List<GameObject> SecBtnList = new List<GameObject>();
    public List<InputField> SecBtnInputList = new List<InputField>();

    public Text BtnNum;
    public string A;
    public int a;

    public int SecBtnNum = 0;

    public Num ButtonNum;
    public ButtonN N;
    public line Line;

    public GameObject ResearchPanel;//研究面板

	// Use this for initialization
	void Start () {

        SecBtnList = new List<GameObject>{ SecBtnObj1, SecBtnObj2, SecBtnObj3, SecBtnObj4, SecBtnObj5, SecBtnObj6,
                                           SecBtnObj7, SecBtnObj8, SecBtnObj9};
        SecBtnInputList = new List<InputField>{ SecInput1, SecInput2, SecInput3, SecInput4, SecInput5, SecInput6,
                                                SecInput7, SecInput8, SecInput9 };

        A = BtnNum.text;
        a = int.Parse(A);

        int j = a * 10 + 1;
        int k = (a + 1) * 10;

        Button btn = FirstBtn.GetComponent<Button>();

        JsonData BtnAttribute = Load.LoadButton();
        FirstName.text = BtnAttribute[a][0].ToString();
        //FirstTitle.text = BtnAttribute[a][1].ToString();
        //FirstIntro.text = BtnAttribute[a][2].ToString();
        if (BtnAttribute[a][0].ToString() != Name)
            FirstName.interactable = false;
        else
            FirstName.transform.SetAsLastSibling();
        if (BtnAttribute[a][1].ToString() != title)
            FirstTitle.interactable = false;

        btn.onClick.AddListener(delegate {
            ResearchPanel.SetActive(false);
            Line.Delete();

            ButtonNum.a = a;
            ButtonNum.b = 0;
            for(int i = 11; i < 50 ; i++)
                N.BtnN[i] = 0;//初始化二级按键的n

            MasterPanel.transform.SetAsLastSibling();
            FirstBtnAdd.transform.SetAsLastSibling();
            FirstBtnEdit.transform.SetAsLastSibling();

            JsonData BtnAttribute1 = Load.LoadButton();
            FirstName.text = BtnAttribute1[a][0].ToString();
            FirstTitle.text = BtnAttribute1[a][1].ToString();
            FirstIntro.text = BtnAttribute1[a][2].ToString();

            int m = 0;
            for (int i = j; i < k; i++)
            {
                SecBtnInputList[m].text = BtnAttribute1[i][0].ToString();

                if (SecBtnInputList[m].text != Name)
                {
                    SecBtnInputList[m].interactable = false;
                    SecBtnInputList[m].transform.SetAsFirstSibling();
                }
                else
                {
                    SecBtnInputList[m].interactable = true;
                    SecBtnInputList[m].transform.SetAsLastSibling();
                }
                m++;
            }

            JsonData BtnNumber = Load.LoadBtnNum();
            SecBtnNum = int.Parse(BtnNumber[a][0].ToString());
            for (int i = 0; i < 9; i++)
            {
                SecBtnList[i].transform.localScale = new Vector3(0, 0, 0);
            }
            for (int i = 0; i < SecBtnNum; i++)
            {
                SecBtnList[i].transform.localScale = new Vector3(0.15f, 0.15f, 0);
            }
        });

        Button btnEdit = FirstBtnEdit.GetComponent<Button>();
        btnEdit.onClick.AddListener(delegate {
            FirstName.interactable = true;
            FirstName.transform.SetAsLastSibling();
            FirstTitle.interactable = true;
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
