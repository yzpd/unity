using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Load : MonoBehaviour {

    public static JsonData LoadButton()
    {

        //获取文件路径。
        StreamReader reader = new StreamReader(Application.persistentDataPath + @"/JsonButton.json");
        string jsonData = reader.ReadToEnd();
        JsonData jsdata3 = JsonMapper.ToObject(jsonData);
        //loadedData = JsonUtility.FromJson<Person>(jsonData);

        reader.Close();
        reader.Dispose();

        return jsdata3;
    }

    public static JsonData LoadResearch()
    {

        //获取文件路径。
        StreamReader reader = new StreamReader(Application.persistentDataPath + @"/JsonResearch.json");
        string jsonData = reader.ReadToEnd();
        JsonData jsdata3 = JsonMapper.ToObject(jsonData);
        //loadedData = JsonUtility.FromJson<Person>(jsonData);

        reader.Close();
        reader.Dispose();

        return jsdata3;
    }

    public static JsonData LoadBtnNum()
    {

        //获取文件路径。
        StreamReader reader = new StreamReader(Application.persistentDataPath + @"/JsonButtonNum.json");
        string jsonData = reader.ReadToEnd();
        JsonData jsdata3 = JsonMapper.ToObject(jsonData);
        //loadedData = JsonUtility.FromJson<Person>(jsonData);

        reader.Close();
        reader.Dispose();

        return jsdata3;
    }
}
