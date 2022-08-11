using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float MinX, MaxX, MinY, MaxY;

    bool isTouch;

    public GameObject bullet;
    [Header("設定多少時間產生一個子彈")]
    public float SetTime;
    float ScriptTime;
    [Header("參考位置")]
    public Transform TargetPoint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKey(Staticvar.KeyboardsState[0]))
        //{
        //    transform.Translate(0, 0, Speed * Time.deltaTime);
        //}
        //else if (Input.GetKey(Staticvar.KeyboardsState[1]))
        //{
        //    transform.Translate(0, 0, -Speed * Time.deltaTime);
        //}
        //else if (Input.GetKey(Staticvar.KeyboardsState[2]))
        //{
        //    transform.Translate(-Speed * Time.deltaTime, 0, 0);
        //}
        //else if (Input.GetKey(Staticvar.KeyboardsState[3]))
        //{
        //    transform.Translate(Speed * Time.deltaTime, 0, 0);
        //}

        //#if UNITY_STANDALONE_WIN
        //        transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        //#endif
        //#if UNITY_ANDROID

        //transform.Translate(Input.acceleration.x * Speed * Time.deltaTime, 0, Input.acceleration.y * Speed * Time.deltaTime);

        //#endif


        if (isTouch)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -2.1f);
        }
        //transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);

        ScriptTime += Time.deltaTime;
        if (ScriptTime>=SetTime) {
            Instantiate(bullet,TargetPoint.transform.position,TargetPoint.transform.transform.rotation);
            ScriptTime = 0;
        }



    }

    private void OnMouseDown()
    {
        isTouch = true;
    }
    private void OnMouseUp()
    {
        isTouch = false;
    }



}
