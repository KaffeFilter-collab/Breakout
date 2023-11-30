using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemaster : MonoBehaviour
{

    public int score = 0;
    public Brick brickPrefab;
    public int Brickamount=0;
    public  delegate void BrickspawnerDelegate(Brick newBrick);
    public event BrickspawnerDelegate Brickspawner;




    private void Awake()
    {
        GameObject.FindAnyObjectByType<Brick>().AllBricksdead += Gamemaster_AllBricksdead;
        GameObject.FindAnyObjectByType<Brick>().Brickshit += Gamemaster_Brickshit;

    }

    private void Gamemaster_Brickshit()
    {
        score++;
    }

    private void Gamemaster_AllBricksdead()
    {
        //Determin sceen index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int targetsceneindex = currentSceneIndex + 1;
        //check if next sceen index is out of bounds
        if (targetsceneindex >= SceneManager.sceneCountInBuildSettings)
        {
            targetsceneindex = 0;
        }
        SceneManager.LoadScene(targetsceneindex);

    }

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
