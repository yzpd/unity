using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class FileInit : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        string filePath = Application.persistentDataPath + @"/JsonButton.json";
        //StreamReader reader = new StreamReader(Application.streamingAssetsPath + @"/JsonButton.json");

        if(!File.Exists(filePath))
            CopyFile(Application.streamingAssetsPath, Application.persistentDataPath);

    }


    void CopyFile(string srcPath, string tarPath)
    {
        string[] filesList = Directory.GetFiles(srcPath);
        foreach (string f in filesList)
        {
            string fTarPath = tarPath + "\\" + f.Substring(srcPath.Length + 1);
            if (File.Exists(fTarPath))
            {
                File.Copy(f, fTarPath, true);
            }
            else
            {
                File.Copy(f, fTarPath);
            }
        }
    }
}
