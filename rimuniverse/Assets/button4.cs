using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button4 : MonoBehaviour {

    public GameObject pic;
    public GameObject btnObj;

    Button btn;

    // Use this for initialization
    void Start () {

        btnObj = new GameObject("Button4", typeof(Button), typeof(RectTransform), typeof(Image));

        btnObj.transform.SetParent(pic.transform);//把pic设置成button的父物体
        btnObj.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        btnObj.transform.localPosition = new Vector3(0,0,0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
