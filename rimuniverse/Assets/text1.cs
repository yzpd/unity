using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text1 : MonoBehaviour {

    Text myText;
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
    //  myText.text = "6666t111";
        myText.text = myText.text.Replace("t", "\n");
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
