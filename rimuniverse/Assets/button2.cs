using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitJson;
using System.Threading;

public class button2 : MonoBehaviour
{
    public GameObject btnObj;//五级按键
    public GameObject FifEditObj;//五级编辑按键
    public GameObject ReaserchBtnObj;//研究按键
    public GameObject Image2;//研究中的蓝色填充Image
    public GameObject ButtonImg;//此按键的内边框
    public GameObject ResearchPanel;//研究面板
    public GameObject ValueT;//数值
    public GameObject ResearchT;//研究Text

    Image ButtonImage;
    Image FillImage;
    Image ButtonImage2;
    Button btn;
    Button btn2;
    Text ValueText;
    Text Research;

    //float StartTime = 0;
    //float SuspendTime = 0;//暂停时过去的时间
    //float Moment = 0;//时刻
    float Interval = 0;//时间间隔
//    float time = 0;//此系数代替系统时间

    bool b = false;

    public Num ButtonNum;
    public SetTime settime;

    public Text BtnDNum;//BtnDNum
    public string D;
    public int d = 0;

    public InputField FifName;
    public InputField FifTitle;
    public InputField FifIntro;
    public string Name = "name";
    public string title = "title";
    public string introduce = "introduce";
    public string ending = "2";

    public InputField SetInput;

    //private Thread tempThread;
    void Start () {

        ResearchPanel.SetActive(false);

        ButtonImage = ButtonImg.GetComponent<Image>();
        FillImage = Image2.GetComponent<Image>();
        btn = btnObj.GetComponent<Button>();
        btn2 = ReaserchBtnObj.GetComponent<Button>();
        ButtonImage2 = ReaserchBtnObj.GetComponent<Image>();
        Research = ResearchT.GetComponent<Text>();
        ValueText = ValueT.GetComponent<Text>();

        D = BtnDNum.text;
        ButtonNum.d = 7;//防止buttonNum.d=0出错

        JsonData jsdata2 = Load.LoadResearch();
        ending = jsdata2[ButtonNum.d][0].ToString();

        btn.onClick.AddListener(delegate ()
        {
            settime.StartT = settime.StartT1;
            settime.StartT[ButtonNum.d] = 1;

            d = int.Parse(D) + ButtonNum.c * 10;
            ButtonNum.d = d;
            FifTitle.interactable = true;//初始化title组件
            JsonData BtnAttribute1 = Load.LoadButton();
            if (BtnAttribute1[d][1].ToString() != title)
                FifTitle.interactable = false;
            FifEditObj.transform.SetAsLastSibling();

            FifName.text = BtnAttribute1[d][0].ToString();
            FifTitle.text = BtnAttribute1[d][1].ToString();
            FifIntro.text = BtnAttribute1[d][2].ToString();

            JsonData jsdata3 = Load.LoadResearch();
            Research.text = jsdata3[ButtonNum.d][0].ToString();
            settime.IntervalTime[ButtonNum.d] = float.Parse(jsdata3[ButtonNum.d][1].ToString());
            ValueText.text = jsdata3[ButtonNum.d][1] + "/" + jsdata3[ButtonNum.d][2];
            settime.SetT[ButtonNum.d] = float.Parse(jsdata3[ButtonNum.d][2].ToString());
            FillImage.fillAmount = settime.IntervalTime[ButtonNum.d] / settime.SetT[ButtonNum.d];

            ResearchPanel.SetActive(true);

            ButtonImage.color = new Color((78f / 255), (78f / 255), (78f / 255), 1);

        });
        btn2.onClick.AddListener(delegate ()
        {
            if (d == ButtonNum.d)
            {
                b = !b;
                if (b)
                {
                    ButtonImage2.color = new Color((56f / 255), (56f / 255), (56f / 255), 1);
                    JsonData jsdata3 = Load.LoadResearch();
                    Research.text = "researching";
                    jsdata3[ButtonNum.d][0] = Research.text;
                    Save.SaveResearch(jsdata3);
                    //Time.timeScale = 1;
                    //StartTime = Time.fixedTime;//开始时间以及结束时间
                    //Debug.Log("EndTime = "+EndTime);
                }
                else
                {
                    JsonData jsdata3 = Load.LoadResearch();
                    Research.text = "research";
                    jsdata3[ButtonNum.d][0] = Research.text;
                    Save.SaveResearch(jsdata3);
                    ButtonImage2.color = new Color((249f / 255), (209f / 255), (22f / 255), 1);
                    //Time.timeScale = 0;
                    //Moment = Time.fixedTime;
                    //SuspendTime = Moment - StartTime + SuspendTime;
                }

                StartCoroutine(TT());
            }
        });

        Button btnEdit = FifEditObj.GetComponent<Button>();
        btnEdit.onClick.AddListener(delegate {
            SetInput.transform.SetAsLastSibling();
            JsonData jsdata3 = Load.LoadResearch();
            SetInput.text = jsdata3[ButtonNum.d][2].ToString();
            SetInput.transform.localScale = new Vector3(0.05f, 0.3f, 0);

            FifName.interactable = true;
            FifName.transform.SetAsLastSibling();
            FifTitle.interactable = true;
        });
    }

    IEnumerator TT()//void Update()
    {
        if (d == ButtonNum.d)
        {
            for(int i = 0;i<100;i++)
            { 
                if (ending != "ending")//等价于text = ending
                {
                    if (b)
                    {
                        /*Invoke 应该是开了线程或者协程*/
                        //Invoke("Delay", 10f);
                        //Delay();
                        yield return new WaitForSeconds(1f);
                        settime.IntervalTime[ButtonNum.d] += 1f;
                        Interval = settime.IntervalTime[ButtonNum.d];
                        Debug.Log("Interval = " + Interval.ToString());
                        //Interval = Time.fixedTime - StartTime + SuspendTime;//Time.fixedTime - StartTime = 新增时间

                        if (Interval < settime.SetT[ButtonNum.d])
                        {
                            FillImage.fillAmount = Interval / settime.SetT[ButtonNum.d];
                            ValueText.text = settime.IntervalTime[ButtonNum.d].ToString("f0") + "/" + settime.SetT[ButtonNum.d].ToString("f0");
                        }

                        else//if (Interval >= settime.SetT[ButtonNum.d])
                        {
                            ButtonImage.color = new Color(0, (64f / 255), (16f / 255), 1);
                            JsonData jsdata3 = Load.LoadResearch();
                            Research.text = "ending";
                            ending = "ending";
                            jsdata3[ButtonNum.d][0] = Research.text;
                            jsdata3[ButtonNum.d][1] = settime.IntervalTime[ButtonNum.d].ToString("f0");
                            Save.SaveResearch(jsdata3);
                        }
                    }
                    else
                    {
                        //CancelInvoke("Delay");
                        JsonData jsdata3 = Load.LoadResearch();
                        jsdata3[ButtonNum.d][1] = settime.IntervalTime[ButtonNum.d].ToString("f0");
                        Save.SaveResearch(jsdata3);
                        yield break;
                    }
                }

            }
        }
        else
            yield break;
    }

    public void Delay()
    {
        Debug.Log("for开始");
        settime.IntervalTime[ButtonNum.d] += 0.4f;
        for (double i = 0; i < 1000000; i++)
        {
            ;
        }
        Debug.Log("for结束");
    }


}
