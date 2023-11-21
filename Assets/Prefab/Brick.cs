using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private static int activeBricks=0;
    public int level = 1;
    public delegate void BrickHitDelegate(Brick brickThatWasHit);
    public static event BrickHitDelegate OnBrickHit;
      public static event BrickHitDelegate NoBricksleft;

    private void Awake(){

    activeBricks++;
                        }


  private void  OnCollisionEnter2D(Collision2D collision) 
  {
   activeBricks--;
     gameObject.SetActive(false);
      OnBrickHit.Invoke(this);


         if(activeBricks =<)     
            NoBricksleft.Invoke()this;

  
    }
  }


