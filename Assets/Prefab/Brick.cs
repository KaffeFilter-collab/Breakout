using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Brick : MonoBehaviour
{
    public GameObject powerup;
    private static int activeBricks = 0;
    private float powerupchance = 0.3f;
    public delegate void allbricksdead();
    public event allbricksdead AllBricksdead;
    public delegate void brickhit();
    public event brickhit Brickshit;

    private void Awake()
    {

        activeBricks++;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        activeBricks--;
        Brickshit?.Invoke();


        if (activeBricks == 0)
        {
            AllBricksdead.Invoke();

        }
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
