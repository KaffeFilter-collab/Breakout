using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
     Rigidbody2D rigidbody2d;
    public float speed;
    public float input;

    public delegate void Powerupdelegate(Powerup.PowerupType pow);
    public event Powerupdelegate PowerupEvent;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(input * speed,0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
             rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x,rigidbody2d.velocity.y);
         }
     

public void ApplyPowerup(Powerup.PowerupType powerup)
    {
        PowerupEvent?.Invoke(powerup);
    }
}