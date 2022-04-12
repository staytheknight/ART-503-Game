using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPower : MonoBehaviour
{
    [SerializeField] Sprite normalPlayer;
    [SerializeField] Sprite smallPlayer;
    float objectScaleNormalX = 0.75f;
    float objectScaleNormalY = 0.75f;
    float objectScaleSmallX = 0.5f;
    float objectScaleSmallY = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {   
            Vector2 objectScale = transform.localScale;
            
            transform.localScale = new Vector2(objectScaleSmallX, objectScaleSmallY);
            // SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            // spriteRenderer.sprite = smallPlayer;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            Vector2 objectScale = transform.localScale;
            transform.localScale = new Vector2(objectScaleNormalX, objectScaleNormalY);
            // SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            // spriteRenderer.sprite = normalPlayer;
        }
    }
}
