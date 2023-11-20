using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brickplacer : MonoBehaviour
{

    public Brick brickPrefab;
    public int AbstandY = 0;
    public int AbstandX = 0;
    
    
    private void Awake()
    {
        GameObject.FindAnyObjectByType<Gamemaster>().Brickspawner += Brickspawner_on;
    }



    private void Brickspawner_on(Brick newBrick)
    {
        Instantiate(brickPrefab, new Vector3(AbstandX, AbstandY), Quaternion.identity);


    }


}
