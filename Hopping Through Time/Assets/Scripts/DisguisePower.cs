using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisguisePower : MonoBehaviour
{
    [SerializeField] Sprite normalPlayer;
    [SerializeField] Sprite diguisePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1"))
        { 
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = normalPlayer;
        } 
        if (Input.GetButtonDown("2"))
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = diguisePlayer;
        } 
    }
}
