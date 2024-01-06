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
    private int lifepoints;
    public int score = 0;
    public Brick brickPrefab;
    public int Brickamount = 0;
    public delegate void BrickspawnerDelegate(Brick newBrick);
    public event BrickspawnerDelegate Brickspawner;
    private GameObject scoretrack;
    private int brickcounteramount=0;


    private void Awake()
    {
      //  GameObject.FindAnyObjectByType<Brick>().Brickspawn += Gamemaster_Counter;
       GameObject.FindAnyObjectByType<Brick>().Brickshit += Gamemaster_Brickshit;
       // Brickspawn();
       print("awake");


    }
    private void Start()
    {
        scoretrack = GameObject.FindGameObjectWithTag("Score");
        scoretrack.GetComponentInChildren<TMP_Text>().text = "Score: " + score;

    }

  
    private void Gamemaster_Brickshit()
    {
        score=score+1;
        Console.WriteLine(score.ToString());
        scoretrack.GetComponentInChildren<TMP_Text>().text = "Score: " + score;
        brickcounteramount--;
            if(Brickamount==0){
    
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
    }

    //private void Gamemaster_Counter()
   // {
       //     brickcounteramount++;
   // }

    public void Brickspawn()
    {

        for (int i = 0; i < Brickamount + 1; i++)
        {
            Brickspawner?.Invoke(brickPrefab);
        }


    }
    
    



}
