
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    string SaveScore = "SaveScore";
    string SaveHeightScore = "SaveHeightScore";

    [Header("�C���̰�����")]
    public Text HeightScoreText;
    [Header("�C������")]
    public Text ScoreText;


    private void Awake()
    {


        //�ˬd�̰��o���̭��O�_���x�s��
        if (PlayerPrefs.HasKey(SaveScore))
        {

            //�p�G�ثe�o��>�̰���
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
        //�p�G�̰��o���|���x�s������ơA�N��Ĥ@����
        else
        {
            PlayerPrefs.SetInt(SaveHeightScore, PlayerPrefs.GetInt(SaveScore));
            HeightScoreText.text = "HeightScore: " + PlayerPrefs.GetInt(SaveScore);

            ScoreText.text = "Score: " + PlayerPrefs.GetInt(SaveScore);
        }


    }

}
