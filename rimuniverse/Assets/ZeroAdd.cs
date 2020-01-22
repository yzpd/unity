using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeroAdd : MonoBehaviour {

    public GameObject firstButton1;
    /*后续增加firstButton区*/

    public GameObject btnObj;//零级新增按键

    //List<GameObject> firstButtonList = new List<GameObject>();
    // Use this for initialization
    void Start () {
        Button btn = btnObj.GetComponent<Button>();
        //firstButtonList = new List<GameObject> { firstButton1 };

        btn.onClick.AddListener(delegate ()
        {
            /*为了以后拓展
            if (firstButtonNum < 2)
                firstButtonNum += 1;

            for (int i = 0; i < firstButtonNum; i++)
            {
                firstButtonList[i].transform.localScale = new Vector3(0.0765f, 0.053f, 0);
            }
            */
            firstButton1.transform.localScale = new Vector3(0.0765f, 0.053f, 0);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
