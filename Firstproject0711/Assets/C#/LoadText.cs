using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{

    [Header("��J�C�Ӥ�r�ۤv��ID")]
    public int ID;

    string SaveLanID = "SaveLanID";

    // Update is called once per frame
    void Update()
    {
        switch (PlayerPrefs.GetInt(SaveLanID))
        {

            //����
            case 0:
                //�H�U�T�ؼg�k���O�u��������}����TEXT�ݩ�
                //GetComponent<Text>().text
                //this.GetComponent<Text>().text
                //    GameObject.Find("ReadText")��M�����W���ӦW�٪�����

                gameObject.GetComponent<Text>().text = FindObjectOfType<ReadText>().CHDatas[ID];
                break;
            //�^��
            case 1:
                gameObject.GetComponent<Text>().text = FindObjectOfType<ReadText>().ENDatas[ID];
                break;

        }


    }
}
