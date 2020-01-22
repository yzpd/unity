using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FifthButton : MonoBehaviour
{
    public GameObject btnObj;//五级按键
    public GameObject btnEdit;//五级按键对应的五级edit按键
    public InputField inputField;//五级按键上的textField

    // Use this for initialization
    void Start()
    {

        Button btn = btnObj.GetComponent<Button>();
        Button btn1 = btnEdit.GetComponent<Button>();

        btnEdit.transform.SetAsFirstSibling();

        btn.onClick.AddListener(delegate ()
        {
            /*
            int count = inputField.transform.GetSiblingIndex();
            inputField.transform.SetSiblingIndex(count + 1);//此方法可以实现类似双击的功能
            */
            btnEdit.transform.SetAsLastSibling();
        });

        btn1.onClick.AddListener(delegate ()
        {
            inputField.interactable = true;
            inputField.transform.SetAsLastSibling();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
