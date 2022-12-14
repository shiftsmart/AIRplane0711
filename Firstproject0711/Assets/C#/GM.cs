using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    [Header("固定每幾秒產生一個物件")]
    public float SetTime;
    [Header("敵人")]
    public GameObject[] Enemys;

    [Header("X邊界最大值")]
    public float MaxX;

    [Header("X邊界最小值")]
    public float MinX;

    [Header("PauseUI")]
    public GameObject PauseUI;

    [Header("玩家總血量")]
    public float TotalHP;

    float ScriptHP;
    [Header("玩家血條")]
    public Image PlayerHPImage;

    [Header("分數文字")]
    public Text ScoreText;
    int TotalScore;
    //暫存遊戲分數
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
