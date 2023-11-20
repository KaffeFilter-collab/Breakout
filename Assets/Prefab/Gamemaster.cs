using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Gamemaster : MonoBehaviour
{


    public Brick brickPrefab;
    public int Brickamount=0;
    public  delegate void BrickspawnerDelegate(Brick newBrick);
    public event BrickspawnerDelegate Brickspawner;

    public void Brickspawn()
    {

        for (int i = 0;i < Brickamount + 1; i++)
        {
            Brickspawner?.Invoke(brickPrefab);              
        }


    }
    private void Start()
    {
        Brickspawn();
    }

    //  Instantiate(brickPrefab, new Vector3(AbstandX, AbstandY), Quaternion.identity,);



}
