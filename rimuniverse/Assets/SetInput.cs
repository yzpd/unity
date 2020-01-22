using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class SetInput : MonoBehaviour
{
    public Num BtnNumber;

    public Text text1;
    void Start()
    {
        GetComponent<InputField>().text = "Set Time!";
    }

    public void OnEndEdit(string s)
    {
        text1.text = s;
        JsonData jsdata3 = Load.LoadResearch();
        jsdata3[BtnNumber.d][2] = text1.text;
        Save.SaveResearch(jsdata3);
        GetComponent<InputField>().transform.localScale = new Vector3(0, 0, 0);
    }

}