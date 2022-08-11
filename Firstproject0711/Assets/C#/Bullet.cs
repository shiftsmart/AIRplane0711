using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("移動速度")]
    public float Speed;

    [Header("消失時間")]
    public float DeleteTime;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Speed*Time.deltaTime);


    }
}
