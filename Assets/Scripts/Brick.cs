using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Brick : MonoBehaviour
{
    public GameObject powerup;
    private float powerupchance = 0.3f;
   
    public BrickManager brickManager;
    public Gamemaster gamemaster;

    public void Awake()
    {
        brickManager=GameObject.FindAnyObjectByType<BrickManager>();
        gamemaster=Gamemaster.FindAnyObjectByType<Gamemaster>();
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        gamemaster.scoreincrease();
        brickManager.OnBeforeBrickDestroy(this);
        Powerupspawn();
        Destroy(gameObject);


    }

    private void Powerupspawn()
    {
        if (powerupchance>=Random.Range(0,1))
        {
            Instantiate(powerup,transform.position,Quaternion.identity);
        }   
    }
}
