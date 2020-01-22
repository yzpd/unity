using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class IntroField : MonoBehaviour
{
    public Num BtnNumber;

    public Text text1;
    void Start()
    {
        GetComponent<InputField>().text = "Welcome To My World!";
    }

    public void OnEndEdit(string s)
    {
        text1.text = s;
        JsonData jsdata3 = Load.LoadButton();
        if (BtnNumber.b == 0)
        {
            jsdata3[BtnNumber.a][2] = text1.text;
            Save.SaveButton(jsdata3);
        }
        else if (BtnNumber.c == 0)
        {
            jsdata3[BtnNumber.b][2] = text1.text;
            Save.SaveButton(jsdata3);
        }
        else if (BtnNumber.d == 0)
        {
            jsdata3[BtnNumber.c][2] = text1.text;
            Save.SaveButton(jsdata3);
        }
        else
        {
            jsdata3[BtnNumber.d][2] = text1.text;
            Save.SaveButton(jsdata3);
        }
    }

}
