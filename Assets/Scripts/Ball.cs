    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public Vector2 initalVelocity;
    public Vector3 startingposition;
    private void Awake()
    {
       
        startingposition =GetComponent<Rigidbody2D>().position;
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }
  
   
         
    
    private void Start()
    {
     
        GetComponent<Rigidbody2D>().velocity = initalVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
     if (collision.gameObject.GetComponent<Rigidbody2D>()) {
            rigidbody2d.velocity = (rigidbody2d.velocity + collision.gameObject.GetComponent<Rigidbody2D>().velocity).normalized * rigidbody2d.velocity.magnitude;
        }
        


    }
  
   
   
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.GetComponent<Collider2D>().gameObject.CompareTag("Topwall")){
         rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x,-rigidbody2d.velocity.y);
            }
    

    

    else{

        rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x,rigidbody2d.velocity.y);

            if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Killzone"))
            {               
              StartCoroutine(death());
                
            }


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
   
        
    
}
