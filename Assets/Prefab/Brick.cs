using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Brick : MonoBehaviour
{
    private static int activeBricks = 0;
    public int level = 1;
    public delegate void allbricksdead();
    public event allbricksdead AllBricksdead;
    public delegate void brickhit();
    public event brickhit AllBrickshit;

    private void Awake()
    {

        activeBricks++;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        activeBricks--;
        AllBrickshit.Invoke();


        if (activeBricks == 0)
        {
            AllBricksdead.Invoke();

        }
        Destroy(gameObject);

        //TODO move somwhere else maby


    }
}
