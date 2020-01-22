using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button3 : MonoBehaviour {

    public GameObject btnImg1;
    public GameObject btnImg2;
    public GameObject btnImg3;
    public GameObject btnImg4;
    public GameObject btnImg5;
    public GameObject btnImg6;
    public GameObject btnImg7;
    public GameObject btnImg8;
    public GameObject btnImg9;
    List<GameObject> btnList = new List<GameObject>();

    public GameObject panel;
    public GameObject btnObjNew;//新增按键
    public Vector3 base_point;//原点

    Button btnNew;
    // Use this for initialization
    void Start() {
        int i = 1;
        btnList = new List<GameObject> { btnImg1, btnImg2, btnImg3, btnImg4, btnImg5, btnImg6, btnImg7, btnImg8, btnImg9};

        btnNew = btnObjNew.GetComponent<Button>();

        btnNew.onClick.AddListener(delegate ()
        {
            if (i <= 8)
            {
                btnList[i].transform.localScale = new Vector3(0.15f, 0.15f, 0);
                i += 1;
            }
        });

        //UnityEditorInternal.ComponentUtility.PasteComponentAsNew(gameObject);

    }

    // Update is called once per frame
    void Update() {

    }

    /*
        //创建外框image
        public static GameObject BorderImage(GameObject fater)
        {
            GameObject imgObj = new GameObject("BorderImg", typeof(Image), typeof(RectTransform));
            imgObj.transform.SetParent(fater.transform);//设父辈
            imgObj.transform.localScale = new Vector3(0.15f, 0.15f, 0);
            Image imgObjImg = imgObj.GetComponent<Image>();
            imgObjImg.color = new Color(1, 1, 1, 1);
            RectTransform imgObjRT = imgObj.GetComponent<RectTransform>();
            imgObjRT.sizeDelta = new Vector2(100, 100);

            return imgObj;
        }

        //创建内填充image
        public static GameObject FillImage(GameObject fater)
        {
            GameObject imgObj = new GameObject("FillImage", typeof(Image), typeof(RectTransform));
            imgObj.transform.SetParent(fater.transform);//设父辈
            imgObj.transform.localScale = new Vector3(0.96f, 0.93f, 0);
            Image imgObjImg = imgObj.GetComponent<Image>();
            imgObjImg.color = new Color((30f / 255), (30f / 255), (30f / 255), 1);
            RectTransform imgObjRT = imgObj.GetComponent<RectTransform>();
            imgObjRT.sizeDelta = new Vector2(100, 100);

            return imgObj;
        }


        //创建内部button
        public static GameObject InsideButton(GameObject fater)
        {
            GameObject btnObj = new GameObject("InsideButton", typeof(Button), typeof(Image), typeof(RectTransform));
            btnObj.transform.SetParent(fater.transform);
            btnObj.transform.localScale = new Vector3(0.6f, 3.5f, 0);
            Image btnObjImg = btnObj.GetComponent<Image>();
            btnObjImg.color = new Color(0, (64f / 255), (16f / 255), 0);
            RectTransform btnObjRT = btnObj.GetComponent<RectTransform>();
            btnObjRT.sizeDelta = new Vector2(160, 30);

            return btnObj;
        }

        public void Complete()
        {
            base_point = new Vector3(-28.75f, 28.75f, 0);
            imgObj1 = BorderImage(panel);
            imgObj2 = FillImage(imgObj1);
            btnObj1 = InsideButton(imgObj2);
            imgObj1.transform.localScale = new Vector3(0.15f, 0.15f, 0);
        }
    */
}


