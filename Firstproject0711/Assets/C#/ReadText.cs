using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadText : MonoBehaviour
{

    //中文擋路徑
    string CHPath;

    string ENPath;
    [Header("顯示中文文字檔資料")]
    public string CHData;
    [Header("顯示英文文字檔資料")]
    public string ENData;
    
    [Header("顯示中文文字檔資料")]
    public string[] CHDatas;
    [Header("顯示英文文字檔資料")]
    public string[] ENDatas;

    public enum Platform { 
    PC,
    Mobile
    
    }

    [Header("選擇要切換的平台")]
    public Platform Platforms;

    WWW CHreader;
    WWW ENreader;


    private void Awake()
    {

        CHPath = Application.streamingAssetsPath + "/CH.txt";
        ENPath = Application.streamingAssetsPath + "/EN.txt";

        switch (Platforms) {
            case Platform.Mobile:
                //透過網址方式把steamingassets資料路徑轉檔
                CHreader = new WWW(CHPath);
                ENreader = new WWW(ENPath);
                CHDatas = CHreader.text.Split('\n');
                ENDatas = ENreader.text.Split('\n');
                break;

            case Platform.PC:
                //讀取路徑的檔案內容
                CHData = File.ReadAllText(CHPath);
                ENData = File.ReadAllText(ENPath);
                //讀出來的資料進行切割
                CHDatas = CHData.Split('\n');
                ENDatas = ENData.Split('\n');
                break;

        }


    }
 

}
