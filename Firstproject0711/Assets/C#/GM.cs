using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    [Header("�T�w�C�X���ͤ@�Ӫ���")]
    public float SetTime;
    [Header("�ĤH")]
    public GameObject[] Enemys;

    [Header("X��ɳ̤j��")]
    public float MaxX;

    [Header("X��ɳ̤p��")]
    public float MinX;

    [Header("PauseUI")]
    public GameObject PauseUI;

    [Header("���a�`��q")]
    public float TotalHP;

    float ScriptHP;
    [Header("���a���")]
    public Image PlayerHPImage;

    [Header("���Ƥ�r")]
    public Text ScoreText;
    int TotalScore;
    //�Ȧs�C������
    string SaveScore = "SaveScore";


    // Start is called before the first frame update
    void Start()
    {
        ScriptHP = TotalHP;
        InvokeRepeating("CreateEnemys", SetTime, SetTime);
    }

    void CreateEnemys()
    {
        Instantiate(Enemys[Random.Range(0, Enemys.Length)], new Vector3(Random.Range(MinX, MaxX), transform.position.y, transform.position.z), transform.rotation);


    }

    // Update is called once per frame
    void Update()
    {
    }


    public void Pause(bool isPause)
    {
        PauseUI.SetActive(isPause ? true : false);

        FindObjectOfType<Player>().enabled = isPause ? false : true;

        Time.timeScale = isPause ? 0 : 1;
    }


    public void HurtPlayer(float Hurt)
    {
        ScriptHP -= Hurt;
        PlayerHPImage.fillAmount = ScriptHP / TotalHP;
        if (PlayerHPImage.fillAmount<=0) {

            PlayerPrefs.SetInt(SaveScore, TotalScore);

            Application.LoadLevel("GameOver");
        
        }

    }

    public void AddScore(int Add) {
        TotalScore += Add;
        ScoreText.text = "Score:" + TotalScore;

    }


}
