using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class FourthBtnName : MonoBehaviour {

    public InputField inputField;
    public Text text1;
    public Text BtnCNum;//BtnCNum
    public Num ButtonNum;

    public string C;
    public int c;

    void Start()
    {
        inputField = GetComponent<InputField>();
    }
    public void OnEndEdit(string s)
    {
        inputField.transform.SetAsFirstSibling();

        C = BtnCNum.text;
        c = int.Parse(C) + ButtonNum.b * 10;

        text1.text = s;
        JsonData jsdata3 = Load.LoadButton();
        jsdata3[c][0] = text1.text;
        Save.SaveButton(jsdata3);

    }
}
