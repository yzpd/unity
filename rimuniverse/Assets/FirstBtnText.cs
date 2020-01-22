using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class FirstBtnText : MonoBehaviour
{
    public InputField inputField;
    public Text text1;
    public Text BtnANum;//BtnANum

    public string A;
    public int a;

    void Start()
    {
        A = BtnANum.text;
        a = int.Parse(A);
        inputField = GetComponent<InputField>();
    }
    public void OnEndEdit(string s)
    {       
        inputField.transform.SetAsFirstSibling();

        text1.text = s;
        JsonData jsdata3 = Load.LoadButton();
        jsdata3[a][0] = text1.text;
        Save.SaveButton(jsdata3);

    }

    /*
    public void OnValueChange(string s)
    {
        text1.text = s;
        //Debug.Log(text1.text);
    }
    */


}
