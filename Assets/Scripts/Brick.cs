using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Brick : MonoBehaviour
{
    public GameObject powerup;
    private float powerupchance = 0.3f;
    public delegate void brickspawn();
    public event brickspawn Brickspawn;
    public delegate void brickhit();
    public event brickhit Brickshit;
    static int Brickamount;
    

    public void Awake()
    {
        Brickamount++;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Brickamount--;
        Brickshit?.Invoke();
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
