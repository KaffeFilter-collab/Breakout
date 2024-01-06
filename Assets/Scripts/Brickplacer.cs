using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brickplacer : MonoBehaviour
{

    public Brick brickPrefab;
    public int AbstandY;
    public int AbstandX;
    
    
    private void Awake()
    {
        GameObject.FindAnyObjectByType<Gamemaster>().Brickspawner += Brickspawner_on;
    }



    private void Brickspawner_on(Brick newBrick)
    {
        for (int  y= -2; y < 2; y++) { 
        
         
            for (int i = 0; i < 3; i++)
            {
                Instantiate(brickPrefab, new Vector3(AbstandX+(i+1), AbstandY+(y+1)), Quaternion.identity);
                
            }
            
        }

    }


}
                                                                                                                        