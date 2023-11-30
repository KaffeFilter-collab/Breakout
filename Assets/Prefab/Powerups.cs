using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public delegate void powerup(Powerup powerup);
    public event powerup powerupcollected;
    public enum Powerup
    {
        stick,
        laser,
        burning
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        Player player = collision.gameObject.GetComponent<Player>();
        Powerup random = (Powerup) Random.Range(0, Powerup.GetNames(typeof(Powerup)).Length);
        print(random);
        powerupcollected.Invoke(random);
        Destroy(gameObject);
    }


}
