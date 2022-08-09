using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{

    [Header("輸入每個文字自己的ID")]
    public int ID;

    string SaveLanID = "SaveLanID";

    // Update is called once per frame
    void Update()
    {
        switch (PlayerPrefs.GetInt(SaveLanID))
        {

            //中文
            case 0:
                //以下三種寫法都是只抓取掛此腳本的TEXT屬性
                //GetComponent<Text>().text
                //this.GetComponent<Text>().text
                //    GameObject.Find("ReadText")找尋場景上有該名稱的物件

                gameObject.GetComponent<Text>().text = FindObjectOfType<ReadText>().CHDatas[ID];
                break;
            //英文
            case 1:
                gameObject.GetComponent<Text>().text = FindObjectOfType<ReadText>().ENDatas[ID];
                break;

        }


    }
}
