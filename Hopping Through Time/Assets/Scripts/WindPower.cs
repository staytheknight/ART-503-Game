using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPower : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;                // Assigned object to be affected by force
    [SerializeField] float xForce;
    [SerializeField] float yForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Wind");
        }
    }

    IEnumerator Wind()
    {
        Vector2 force = new Vector2(xForce, yForce);
        yield return new WaitForSeconds(1f);
        GetComponent<CharacterController2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        rb2d.AddForce(force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.75f);
        GetComponent<CharacterController2D>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        /*
        force = new Vector2(xForce, 0);
        yield return new WaitForSeconds(0.2f);
        rb2d.AddForce(force, ForceMode2D.Impulse);
        */
    }


}
