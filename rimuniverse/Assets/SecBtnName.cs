using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class SecBtnName : MonoBehaviour {

    public InputField inputField;
    public Text text1;
    public Text BtnBNum;//BtnBNum
    public Num ButtonNum;

    public string B;
    public int b;

    void Start()
    {
        inputField = GetComponent<InputField>();
    }
    public void OnEndEdit(string s)
    {
        inputField.transform.SetAsFirstSibling();

        B = BtnBNum.text;
        b = int.Parse(B) + ButtonNum.a * 10;

        text1.text = s;
        JsonData jsdata3 = Load.LoadButton();
        jsdata3[b][0] = text1.text;
        Save.SaveButton(jsdata3);

    }
}
