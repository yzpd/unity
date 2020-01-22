using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class edit : MonoBehaviour
{

    public GameObject btnObj;
    public InputField inputtext;
    Button btn;

    // Use this for initialization
    void Start()
    {

        btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            inputtext.readOnly = false;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
