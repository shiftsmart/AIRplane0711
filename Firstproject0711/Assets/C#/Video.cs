using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class Video : MonoBehaviour
{
    public VideoPlayer videoObj;
    bool VideoState;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(1f);
        VideoState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoObj.isPlaying&&VideoState) {
            Application.LoadLevel("Game");

        }


    }
}
