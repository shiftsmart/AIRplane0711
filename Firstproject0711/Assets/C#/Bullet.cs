using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("簿笆硉")]
    public float Speed;

    [Header("ア丁")]
    public float DeleteTime;

    public enum SetState { 
    PlayerBullet,
    EnemyBullet
    
    }
    public SetState SetStates;

    [Header("采╰参_Player")]
    public GameObject PlayerExp;
    [Header("采╰参_Enemy")]
    public GameObject EnemyExp;

    public float HurtPlayerNum;
    public int AddScore;


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

    private void OnTriggerEnter(Collider hit)
    {
        switch (SetStates)
        {
            case SetState.PlayerBullet:

                if (hit.GetComponent<Collider>().tag=="Enemy"||hit.GetComponent<Collider>().tag=="Asteroid") {

                    FindObjectOfType<GM>().AddScore(AddScore);
                    Instantiate(EnemyExp,hit.transform.position, hit.transform.rotation);

                    Destroy(hit.gameObject);
                    Destroy(gameObject);
                }


                break;
            case SetState.EnemyBullet:
                if (hit.GetComponent<Collider>().tag=="Player") {

                    FindObjectOfType<GM>().HurtPlayer(HurtPlayerNum);
                    Instantiate(PlayerExp,hit.transform.position,hit.transform.rotation);
                    Destroy(gameObject);                
                }


                break;
            default:
                break;
        }


    }


}
