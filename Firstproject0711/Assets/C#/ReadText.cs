using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadText : MonoBehaviour
{

    //����׸��|
    string CHPath;

    string ENPath;
    [Header("��ܤ����r�ɸ��")]
    public string CHData;
    [Header("��ܭ^���r�ɸ��")]
    public string ENData;
    
    [Header("��ܤ����r�ɸ��")]
    public string[] CHDatas;
    [Header("��ܭ^���r�ɸ��")]
    public string[] ENDatas;

    public enum Platform { 
    PC,
    Mobile
    
    }

    [Header("��ܭn���������x")]
    public Platform Platforms;

    WWW CHreader;
    WWW ENreader;


    private void Awake()
    {

        CHPath = Application.streamingAssetsPath + "/CH.txt";
        ENPath = Application.streamingAssetsPath + "/EN.txt";

        switch (Platforms) {
            case Platform.Mobile:
                //�z�L���}�覡��steamingassets��Ƹ��|����
                CHreader = new WWW(CHPath);
                ENreader = new WWW(ENPath);
                CHDatas = CHreader.text.Split('\n');
                ENDatas = ENreader.text.Split('\n');
                break;

            case Platform.PC:
                //Ū�����|���ɮפ��e
                CHData = File.ReadAllText(CHPath);
                ENData = File.ReadAllText(ENPath);
                //Ū�X�Ӫ���ƶi�����
                CHDatas = CHData.Split('\n');
                ENDatas = ENData.Split('\n');
                break;

        }


    }
 

}
