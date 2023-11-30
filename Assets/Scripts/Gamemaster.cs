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



    private void Awake()
    {
        GameObject.FindAnyObjectByType<Brick>().AllBricksdead += Gamemaster_AllBricksdead;
        GameObject.FindAnyObjectByType<Brick>().Brickshit += Gamemaster_Brickshit;
        if (GameObject.FindAnyObjectByType<Powerups>())
            GameObject.FindAnyObjectByType<Powerups>().powerupcollected += Gamemaster_powerupcollected;


    }
    private void Start()
    {
        scoretrack = GameObject.FindGameObjectWithTag("Score");
        scoretrack.GetComponentInChildren<TMP_Text>().text = "Score: " + score;

    }

    private void Gamemaster_powerupcollected(Powerups.Powerup powerup)
    {
        if (powerup == Powerups.Powerup.stick) stick();
        if (powerup == Powerups.Powerup.laser) laser();
        if (powerup == Powerups.Powerup.burning) burning();

    }

    private void Gamemaster_Brickshit()
    {
        score++;
        Console.WriteLine(score.ToString());
        scoretrack.GetComponentInChildren<TMP_Text>().text = "Score: " + score;
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

        for (int i = 0; i < Brickamount + 1; i++)
        {
            Brickspawner?.Invoke(brickPrefab);
        }


    }
    private void stick()
    {


    }

    private void laser()
    {

    }

    private void burning()
    {

    }



}
