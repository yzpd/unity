using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class FifthBtnName : MonoBehaviour {

    public InputField inputField;
    public Text text1;
    public Text BtnDNum;//BtnDNum
    public Num ButtonNum;

    public string D;
    public int d;

    void Start()
    {
        inputField = GetComponent<InputField>();
    }
    public void OnEndEdit(string s)
    {
        inputField.transform.SetAsFirstSibling();

        D = BtnDNum.text;
        d = int.Parse(D) + ButtonNum.c * 10;

        text1.text = s;
        JsonData jsdata3 = Load.LoadButton();
        jsdata3[d][0] = text1.text;
        Save.SaveButton(jsdata3);

    }
}
