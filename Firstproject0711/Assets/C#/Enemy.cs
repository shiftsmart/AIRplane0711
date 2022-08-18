using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Speed;
    public float DeleteTime;

    public GameObject Bullet;
    [Header("設定多少時間產生一個子彈")]
    public float SetTime;
    [Header("參考位置")]
    public Transform TargetPoint;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeleteTime);
        if (gameObject.tag == "Enemy")
        {
            InvokeRepeating("CreateBullets", SetTime, SetTime);
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }


    void CreateBullets()
    {

        Instantiate(Bullet, TargetPoint.transform.position, TargetPoint.transform.rotation);

    }
}
