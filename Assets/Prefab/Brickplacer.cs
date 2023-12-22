using System.Collections;
using System.Collections.Generic;
using UnityEngine;




   public class Brickplacer : MonoBehaviour
{

    public Brick brickPrefab;
    public int AbstandY = 05;
    public int AbstandX = 10;
    
    
    private void Awake()
    {
        GameObject.FindAnyObjectByType<Gamemaster>().Brickspawner += Brickspawner_on;
    }



    private void Brickspawner_on(Brick newBrick)
    {
        for (int  y= 0; y < 3; y++) { 
        
         
            for (int i = 0; i < 3; i++)
            {
<<<<<<< Updated upstream
                Instantiate(brickPrefab, new Vector3(AbstandX*(i+3), AbstandY*(y-1)), Quaternion.identity);
=======
                Instantiate(brickPrefab, new Vector3(AbstandX*(i+5), AbstandY*(y-2)), Quaternion.identity);
>>>>>>> Stashed changes
                
            }
            
        }

    }


}
