using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Audio;

public class menu : MonoBehaviour
{
    [Header("BGM")]
    public GameObject BGM;


    bool ControlAudio;
    //[Header("�n���}�Ϥ�")]
    //public Sprite OpenSound;


    //[Header("�n�����Ϥ�")]
    //public Sprite CloseSound;

    [Header("�n�����s")]
    public Image ButtonSound;


    public string[] filePaths;


    [Header("�վ㭵�qSlider")]
    public Slider ChangeAudioSlider;

    [Header("AudioMixer")]
    public AudioMixer AudioMixerObj;

    [Header("�ѪR��Dropdown")]
    public Dropdown SizeDropdown;

    [Header("�y��Dropdown")]

    public Dropdown LanDropdown;
    string SaveLanID = "SaveLanID";

    private void Awake()
    {
#if UNITY_STANDALONE_WIN
        SizeDropdown.interactable = true;
#endif
#if UNITY_ANDROID || UNITY_IOS
        SizeDropdown.interactable = false;

#endif

    }

    // Start is called before the first frame update
    void Start()
    {
        filePaths = Directory.GetFiles(Application.streamingAssetsPath,"*.png");
        if (GameObject.FindGameObjectsWithTag("BGM").Length<=0) {
            Instantiate(BGM);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotostage() {

        SceneManager.LoadScene("stage");

    }

    public void Quit()
    {
       


        Application.Quit();
    }

    void StreamingAssetsLoadTexture(int ID) {
        byte[] pngBytes = File.ReadAllBytes(filePaths[ID]);
        Texture2D tex = new Texture2D(0,0);

        tex.LoadImage(pngBytes);

        Sprite FormTex = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f,0.5f));
        ButtonSound.sprite = FormTex;


    }

    public void ChangeAudio_Slider()
    {

        //AudioListener.volume = ChangeAudioSlider.value;
        AudioMixerObj.SetFloat("BGM",ChangeAudioSlider.value);
    }

    public void Control_Audio()
    {
        ControlAudio = !ControlAudio;

        if (ControlAudio)
        {

            //ButtonSound.sprite = Resources.Load<Sprite>("OpenSound");
            StreamingAssetsLoadTexture(1);
        }
        else
        {
            //ButtonSound.sprite = Resources.Load<Sprite>("CloseSound");
            StreamingAssetsLoadTexture(0);
        }




        AudioListener.pause = ControlAudio;

    }
    public void ChangeScreenSize() {

        switch (SizeDropdown.value) {
            case 0:
                Screen.SetResolution(1080,1920,false);
                break;
            case 1:
                Screen.SetResolution(720, 1280, false);
                break;
            case 2:
                Screen.SetResolution(480, 800, false);
                break;




        }

    }


    public void ChangeLan() {
        PlayerPrefs.SetInt(SaveLanID,LanDropdown.value);
    
    }

}
