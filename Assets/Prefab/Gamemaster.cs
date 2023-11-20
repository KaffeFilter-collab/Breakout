using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaster : MonoBehaviour
{


    public Brick brickPrefab;
    public int Brickamount=0;
    public int AbstandY = 0;
    public int AbstandX = 0;
    

    private void Brickspawn()
    {

        for (int i = 0;i < Brickamount + 1; i++)
        {

            Instantiate(brickPrefab, new Vector3(AbstandX, AbstandY), Quaternion.identity,);
            
        }


    }
    private void Start()
    {
        Brickspawn();
    }





}
