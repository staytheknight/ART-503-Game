using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPower : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;                // Assigned object to be affected by force
    [SerializeField] float xForce;
    [SerializeField] float yForce;
    int sideFlag = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;

            // Clicked on left side of screen
            if (mousePos.x < (Screen.width/2))
            {
                
                if (sideFlag != 0)
                {
                    sideFlag = 0;
                }

                StartCoroutine("Wind", sideFlag);
            }

            // Clicked on right side of screen
            else if (mousePos.x > (Screen.width/2))
            {
                   
                if (sideFlag != 1)
                {
                    sideFlag = 1;
                }

                StartCoroutine("Wind", sideFlag);
            }
            
            
        }


    }

    IEnumerator Wind(int sideFlag)
    {

        Vector2 force = new Vector2(xForce, yForce);
        
        // Wait one second before triggering the impulse
        yield return new WaitForSeconds(1f);
        // The player controllers need to be turned off in order for proper physics to work
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
        GetComponent<CharacterController2D>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;

    }


}
