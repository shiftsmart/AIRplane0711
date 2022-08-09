using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveSettingData : MonoBehaviour
{
    //���g�إߤ�r�ɪ����|
    string Path;
    [Header("�y���U�Կ��")]
    public Dropdown LanDropdown;
    [Header("�ѪR�פU�Կ��")]
    public Dropdown ScreenSizeDropdown;
    //Ū����r�ɡA�åB�N��Ƽg�J��Ū��
    FileStream file;

    public enum Platform
    {
        PC,
        Mobile

    }

    [Header("��ܭn���������x")]
    public Platform Platforms;
    [Header("��ܤ�r�ɨ��Dropdown���")]
    public string[] Datas;
    WWW Reader;
    string ReaderPC;


    private void Awake()
    {
        //�إߤ@�Ӥ�r�ɦW�٬�save.txt�A���x�s�bapplication.persistentDataPath���|�U
        Path = Application.persistentDataPath + "Save.txt";

        if (File.Exists(Path))
        {
            Debug.Log("������������r��");
            ReadString();
        }
        //�ˬd�����|�O�_�w�g����r��=>�p�G�Ǧ^false�S����r��
        else {
            Debug.Log("�b����إߤ@�Ӥ�r��");
            //�إߤ@�Ӥ�r��
            file = new FileStream(Path, FileMode.Create);
            file.Close();
        
        }

    }
    //���U��^���s�N�۰��x�s�ѪR�שM�y����dropdown value
    public void SaveData() {

        WriteString(ScreenSizeDropdown.value+"@"+LanDropdown.value);
        Debug.Log(Path);
    }
    void WriteString(string Data) {
        //���application.persistentDataPath���|�U����r�ɮרö}��
        file = new FileStream(Path,FileMode.Open);
        //��n�x�s����ƪ���r��
        StreamWriter sw = new StreamWriter(file);
        
        //�b��r�ɼg�J�n�x�s����r
        
        sw.WriteLine(Data);
        //��Ƽg�J����������r��
        sw.Close();

    }
    void ReadString() {
        switch (Platforms) {


            case Platform.Mobile:
                //�z�L���}�覡���r�ɧ����|���ɨ�Ū�X��r�ɤ��e
                Reader = new WWW(Path);
                //�NŪ������r�ɦ�@������
                Datas = Reader.text.Split('@');
                //int.parse��r�ন��ƭ�
                ScreenSizeDropdown.value = int.Parse(Datas[0]);
                LanDropdown.value = int.Parse(Datas[1]);
                
                break;
            case Platform.PC:
              //  Ū�����|����r�ɤ��e
                ReaderPC = File.ReadAllText(Path);
                Datas = ReaderPC.Split('@');
                ScreenSizeDropdown.value = int.Parse(Datas[0]);
                LanDropdown.value = int.Parse(Datas[1]);
                break;

        }
    
    
    }

  
}
