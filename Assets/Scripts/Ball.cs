    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    private bool stick=false;
    Rigidbody2D rigidbody2d;
    public Vector2 initalVelocity;
    public Vector3 startingposition;
    
    private Player player;
    private void Awake()
    {
       
        startingposition =GetComponent<Rigidbody2D>().position;
        rigidbody2d = GetComponent<Rigidbody2D>();
        player=GameObject.FindAnyObjectByType<Player>();
        player.PowerupEvent += OnPowerupEvent;
        
    }
  
   
         
    
    private void Start()
    {
     
        GetComponent<Rigidbody2D>().velocity = initalVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.CompareTag("Player"))
        {
            if(stick==false)
            {
                rigidbody2d.velocity = (rigidbody2d.velocity + collision.gameObject.GetComponent<Rigidbody2D>().velocity).normalized * rigidbody2d.velocity.magnitude;
            }
            
            else
            {               
                Vector2 targetgeschwindigkeit=(rigidbody2d.velocity + collision.gameObject.GetComponent<Rigidbody2D>().velocity).normalized * rigidbody2d.velocity.magnitude;
                StartCoroutine (wait(targetgeschwindigkeit));
                
            }
        } 


    }
  
   private void OnPowerupEvent(Powerup.PowerupType powerup)
   {
        switch (powerup)
        {
            case Powerup.PowerupType.stick:
                //working
                stick=true;
                break;   

            case Powerup.PowerupType.burning:
                             
                break;
            case Powerup.PowerupType.laser:
                 print("L powerup");
                break;
            default:
                print("no");
                    break;
        }
   }
   
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Killzone"))
            {               
              StartCoroutine(death());
        }   
    }
    
    IEnumerator death()
    {
    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x * 0, rigidbody2d.velocity.y * 0);
    transform.position = startingposition;
    while(!Input.GetKeyDown(KeyCode.Space))
    {
        yield return null;
    }
        rigidbody2d.velocity =initalVelocity;
    }
   
   
   IEnumerator wait(Vector2 targetgeschwindigkeit)
   {
    rigidbody2d.velocity=Vector2.zero;
    while(!Input.GetKeyDown(KeyCode.Space))
    {
        rigidbody2d.velocity=player.GetComponent<Rigidbody2D>().velocity;
        yield return null;
    }
    rigidbody2d.velocity=targetgeschwindigkeit;
    stick=false;
   }
    

    
}
