using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnText : MonoBehaviour
{
    public InputField inputField;
    public Text text1;
//    public Image inputImg;

    void Start()
    {
        inputField = GetComponent<InputField>();
//        inputImg = GetComponent<Image>();
        inputField.transform.SetAsLastSibling();
    }

    public void OnValueChange(string s)
    {
        text1.text = s;
        //Debug.Log(text1.text);
    }

    public void OnEndEdit(string s)
    {
        inputField.transform.SetAsFirstSibling();
    }
}
