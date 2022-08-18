
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    string SaveScore = "SaveScore";
    string SaveHeightScore = "SaveHeightScore";

    [Header("遊戲最高分數")]
    public Text HeightScoreText;
    [Header("遊戲分數")]
    public Text ScoreText;


    private void Awake()
    {


        //檢查最高得分裡面是否有儲存值
        if (PlayerPrefs.HasKey(SaveScore))
        {

            //如果目前得分>最高分
            if (PlayerPrefs.GetInt(SaveScore) > PlayerPrefs.GetInt(SaveHeightScore))
            {

                PlayerPrefs.SetInt(SaveHeightScore, PlayerPrefs.GetInt(SaveScore));
                HeightScoreText.text = "HeightScore: " + PlayerPrefs.GetInt(SaveScore);
                ScoreText.text = "Score: " + PlayerPrefs.GetInt(SaveScore);


            }
            else
            {
                HeightScoreText.text = "HeightScore: " + PlayerPrefs.GetInt(SaveScore);

                ScoreText.text = "Score: " + PlayerPrefs.GetInt(SaveScore);
            }


        }
        //如果最高得分尚未儲存任何分數，代表第一次玩
        else
        {
            PlayerPrefs.SetInt(SaveHeightScore, PlayerPrefs.GetInt(SaveScore));
            HeightScoreText.text = "HeightScore: " + PlayerPrefs.GetInt(SaveScore);

            ScoreText.text = "Score: " + PlayerPrefs.GetInt(SaveScore);
        }


    }

}
