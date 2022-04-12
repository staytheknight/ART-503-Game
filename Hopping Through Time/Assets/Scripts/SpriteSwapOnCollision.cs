using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapOnCollision : MonoBehaviour
{   

    [SerializeField] Sprite otherSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AidBook"))
        {
        collision.gameObject.GetComponent<SpriteRenderer>().sprite = otherSprite;
        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;             //Turns off Collision
        }
    }
}
