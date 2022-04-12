using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{   
    // Sprite for the empty powerup
    [SerializeField] Sprite powerupGot;
    [SerializeField] bool mushPowerGot = false;
    [SerializeField] bool windPowerGot = false;
    [SerializeField] bool shrinkPowerGot = false;
    [SerializeField] bool disguisePowerGot = false;
    [SerializeField] GameObject mushPower;
    [SerializeField] GameObject windPower;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player connects with the Mushroom upgrade:
        if (collision.collider.CompareTag("MushPower"))
        {
            // Turns on the mushroom platform script
            GetComponent<MushPlatformSpawn>().enabled = true;
            mushPowerGot = true;
            // Replaces the powerup plinth with empty plinth
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = powerupGot;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;


            // If the mushroom power is gotten while the wind power is obtained, turn off the wind power
            // TODO : There is a better implementation, will need to remove later
            if (GetComponent<WindPower>().enabled == true) 
            {
                GetComponent<WindPower>().enabled = false;
            }
        }
        if (collision.collider.CompareTag("WindPower"))
        {
            // Turns on the air platform script
            GetComponent<WindPower>().enabled = true;
            windPowerGot = true;
            // Replaces the powerup plinth with empty plinth
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = powerupGot;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;

            // If the wind power is gotten while the mushroom power is obtained, turn off the mushroom power
            // TODO : There is a better implementation, will need to remove later
            if (GetComponent<MushPlatformSpawn>().enabled == true) 
            {
                GetComponent<MushPlatformSpawn>().enabled = false;
            }
        }
        if (collision.collider.CompareTag("ShrinkPower"))
        {
            // Turns on the air platform script
            GetComponent<ShrinkPower>().enabled = true;
            shrinkPowerGot = true;
            // Replaces the powerup plinth with empty plinth
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = powerupGot;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        if (collision.collider.CompareTag("DisguisePower"))
        {
            // Turns on the air platform script
            GetComponent<DisguisePower>().enabled = true;
            shrinkPowerGot = true;
            // Replaces the powerup plinth with empty plinth
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = powerupGot;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }


    // Quick dirty powerup swap, better implementation is an array where the power that is currently in the
    // selected index is turned on, others are turned off - use modulo to wrap around the array
    void Update() {
        if (mushPowerGot == true && windPowerGot == true) 
        {
            if (GetComponent<MushPlatformSpawn>().enabled == false && GetComponent<WindPower>().enabled == true) 
            {
                PowerSprite(windPower);

                if (Input.GetButtonDown("Q")) 
                {
                    GetComponent<MushPlatformSpawn>().enabled = true;
                    GetComponent<WindPower>().enabled = false;
                }
            }

            if (GetComponent<WindPower>().enabled == false && GetComponent<MushPlatformSpawn>().enabled == true)
            {
                PowerSprite(mushPower);

                if (Input.GetButtonDown("E")) 
                {
                    GetComponent<MushPlatformSpawn>().enabled = false;
                    GetComponent<WindPower>().enabled = true;
                }
            }

        }

    }


    // Scrapped together method to create a powerup sprite that follows the player
    void PowerSprite(GameObject sprite) {
        GameObject player = GameObject.Find("Player"); 
        Vector3 spriteLoc = new Vector3(-1,1,0);
        spriteLoc += player.transform.position; 
        Instantiate(sprite, spriteLoc, Quaternion.identity);        
    }
}
