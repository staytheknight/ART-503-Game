using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPower : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;                // Assigned object to be affected by force
    [SerializeField] float xForce;
    [SerializeField] float yForce;
    [SerializeField] int powerCount = 1;
    int sideFlag = 0;

    [SerializeField] GameObject cloudSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(powerCount >= 1) 
            {
            StartCoroutine("timer");
            Vector2 mousePos = Input.mousePosition;

            // Clicked on left side of screen
            if (mousePos.x < (Screen.width/2))
            {
                
                if (sideFlag != 0)
                {
                    sideFlag = 0;
                }

                StartCoroutine("Wind", sideFlag);
                windGraphic(sideFlag);
            }

            // Clicked on right side of screen
            else if (mousePos.x > (Screen.width/2))
            {
                   
                if (sideFlag != 1)
                {
                    sideFlag = 1;
                }

                StartCoroutine("Wind", sideFlag);
                windGraphic(sideFlag);
            }
            }      
        }
    }

    IEnumerator Wind(int sideFlag)
    {

        Vector2 force = new Vector2(xForce, yForce);
        
        // Wait one second before triggering the impulse
        yield return new WaitForSeconds(1f);
        // The player controllers need to be turned off in order for proper physics to work
        // TODO : probably put the toggle in a grounded check
        GetComponent<CharacterController2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;

        // If left side of screen is clicked, impulse to the right
        if (sideFlag == 0)
        {
            rb2d.AddForce(force, ForceMode2D.Impulse);
        }
        
        // If right side of screen is clicked, impulse to the left side
        else
        {
            force = new Vector2(-xForce, yForce);
            rb2d.AddForce(force, ForceMode2D.Impulse);
        }  

        // Turn the controllers back on after 0.75 seconds
        yield return new WaitForSeconds(0.75f);

        // Turns character controller back on
        GetComponent<CharacterController2D>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;

    }

    void windGraphic(int sideFlag) 
    {
        GameObject player = GameObject.Find("Player");                      // Gets position of player
        Vector3 spriteLoc = new Vector3(0,-0.4f,0);                             // Creates a new vector for the location of the sprite

        // If the player clicked on the left side of the screen, the graphic will appear on the left side of the character
        if(sideFlag == 0)
        {
            Vector3 leftOffset = new Vector3(-0.5f,0,0);
            spriteLoc += leftOffset;
        }
        // If the player clicked on the right side of the screen, the graphic will appear on the right side of the character
        if(sideFlag == 1)
        {
            Vector3 rightOffset = new Vector3(0.5f,0,0);
            spriteLoc +=  rightOffset;
        }
        
        spriteLoc += player.transform.position;                             // Adds the location of the sprite to where the player is
        Instantiate(cloudSprite, spriteLoc, Quaternion.identity);           // Creates the sprite
        
    }

    // Function to control how many platforms are available after x seconds
    IEnumerator timer()
    {
        powerCount --;
        yield return new WaitForSeconds(2f);
        powerCount ++;
    }


}
