
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
     public enum PowerupType
    {
        
        stick,
        laser,
        burning
    }
    
    public PowerupType type;
    
    private void Awake()
    {
    type=(PowerupType)Random.Range(0,3);

    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        Player player = collision.gameObject.GetComponent<Player>();
        player.ApplyPowerup(type);      
        Destroy(gameObject);
        
         if (collision.gameObject.CompareTag("Killzone"))
         {
            Destroy(gameObject);
         }

    }
    


}
