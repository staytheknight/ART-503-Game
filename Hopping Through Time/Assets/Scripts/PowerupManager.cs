using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{   
    // Sprite for the empty powerup
    [SerializeField] Sprite powerupGot;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player connects with the Mushroom upgrade:
        if (collision.collider.CompareTag("MushPower"))
        {
            // Turns on the mushroom platform script
            GetComponent<MushPlatformSpawn>().enabled = true;
            // Replaces the powerup plinth with empty plinth
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = powerupGot;
        }
        if (collision.collider.CompareTag("WindPower"))
        {
            // Turns on the air platform script
            GetComponent<WindPower>().enabled = true;
            // Replaces the powerup plinth with empty plinth
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = powerupGot;
        }
    }
}
