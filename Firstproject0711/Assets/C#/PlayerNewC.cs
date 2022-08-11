using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNewC : MonoBehaviour
{
    public PlayerController PlayerControls;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControls = new PlayerController();
        PlayerControls.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2d = PlayerControls.Player.Movement.ReadValue<Vector2>();
        transform.Translate(vector2d.x*Speed*Time.deltaTime,0,vector2d.y*Speed*Time.deltaTime);

    }
}
