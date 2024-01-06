using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
     public enum PowerupType
    {
        [HideInInspector]
        stick,
        laser,
        burning
    }

    public PowerupType type;
    
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        Player player = collision.gameObject.GetComponent<Player>();
        player.ApplyPowerup(this);      
        Destroy(gameObject);
        
         if (collision.gameObject.CompareTag("Killzone"))
         {
            Destroy(gameObject);
         }

    }
    


}
